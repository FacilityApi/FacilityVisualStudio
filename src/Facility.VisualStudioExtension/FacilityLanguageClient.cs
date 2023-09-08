using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Utilities;

namespace Facility.VisualStudioExtension
{
	[ContentType("fsd")]
	[Export(typeof(ILanguageClient))]
	public sealed class FacilityLanguageClient : ILanguageClient, IDisposable
	{
		public string Name => "Facility API Language Extension";

		public IEnumerable<string> ConfigurationSections => null;

		public object InitializationOptions => null;

		public IEnumerable<string> FilesToWatch => null;

		public bool ShowNotificationOnInitializeFailed => true;

		public event AsyncEventHandler<EventArgs> StartAsync;

		public event AsyncEventHandler<EventArgs> StopAsync;

		public async Task<Connection> ActivateAsync(CancellationToken token)
		{
			await Task.Yield();

			m_process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Server", "Facility.LanguageServer.exe"),
					Arguments = "-lsp",
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true,
				},
			};

			if (m_process.Start())
				return new Connection(m_process.StandardOutput.BaseStream, m_process.StandardInput.BaseStream);

			return null;
		}

		public async Task OnLoadedAsync()
		{
			await StartAsync.InvokeAsync(this, EventArgs.Empty);
		}

		public Task OnServerInitializedAsync() => Task.CompletedTask;

		public async Task<InitializationFailureContext> OnServerInitializeFailedAsync(ILanguageClientInitializationInfo initializationState)
		{
			return new InitializationFailureContext { FailureMessage = initializationState.StatusMessage };
		}

		public void Dispose()
		{
			if (m_process != null)
			{
				if (!m_process.HasExited)
					m_process.Kill();
				m_process.Dispose();
				m_process = null;
			}
		}

		private Process m_process;
	}
}
