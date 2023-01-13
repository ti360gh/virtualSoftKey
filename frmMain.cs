using VS = FSUIPC.MSFSVariableServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace virtualSoftKey
{
	public partial class frmMain : Form
	{

		private int _wait = 100;
		public void safeWait(int milliseconds)
		{
			long tickStop = Environment.TickCount + milliseconds;
			while (Environment.TickCount < tickStop)
			{
				Application.DoEvents();
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")] private static extern int SetForegroundWindow(IntPtr hwnd);
		private void switchToMSFS()
		{
			// get the process
			Process bProcess = Process.GetProcessesByName("FlightSimulator").FirstOrDefault();

			// check if the process is running
			if (bProcess != null)
			{
				safeWait(_wait);
				// set user the focus to the window
				SetForegroundWindow(bProcess.MainWindowHandle);
			}
		}
		private void connectToWASM()
		{
			if (VS.IsRunning == false)
			{
				debug_message.Text = "Connecting to WASM...";
				VS.Start();
				if (VS.IsRunning == false)
				{
					debug_message.Text = "connect failed.";
				}
				else
				{
					debug_message.Text = "WASM connected!";
					safeWait(1000);
					debug_message.Text = "";
				}
			}
		}

		public frmMain()
		{
			InitializeComponent();

			// Initialize and connecting FSUIPC WASM Client
			VS.Init();
			connectToWASM();
		}

		// Form is closing so stop the FSUIPC WASM Client
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			VS.Stop();
			Properties.Settings.Default.Location = this.Location;
			Properties.Settings.Default.Size = this.Size;
			Properties.Settings.Default.lockPosition = this.lockPositionMenuItem.Checked;
			Properties.Settings.Default.mode = this.eventMode;
			Properties.Settings.Default.Save();

		}
		private void frmMain_Load(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.Size != new Size(0, 0))
			{
				this.Size = Properties.Settings.Default.Size;
				this.Location = Properties.Settings.Default.Location;
				this.lockPositionMenuItem.Checked = Properties.Settings.Default.lockPosition;
				this.eventMode = Properties.Settings.Default.mode;
				button1.Text = this.eventMode;
			}
		}

		private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Rectangle r = e.CellBounds;

			using (Pen pen = new Pen(Color.DarkGray, 2 /*1px width despite of page scale, dpi, page units*/ ))
			{
				pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
				// define border style
				pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

				// decrease border rectangle height/width by pen's width for last row/column cell
				if (e.Row == (tableLayoutPanel1.RowCount - 1))
				{
					r.Height -= 1;
				}

				if (e.Column == (tableLayoutPanel1.ColumnCount - 1))
				{
					r.Width -= 1;
				}

				// use graphics mehtods to draw cell's border
				e.Graphics.DrawRectangle(pen, r);
			}
		}

		private string eventMode = "MFD";
		private void button1_Click(object sender, EventArgs e)
		{
			connectToWASM();
			if (eventMode == "MFD")
			{
				this.eventMode = "PFD";
			}
			else
			{
				this.eventMode = "MFD";
			}
			button1.Text = this.eventMode;
			switchToMSFS();
		}

		private void sendHver(string hvar)
		{
			connectToWASM();
#if DEBUG
			debug_message.Text = "sending " + hvar;
#endif
			if (VS.HVars.Exists(hvar))
			{
				VS.HVars[hvar].Set();
#if DEBUG
				debug_message.Text = hvar + "_send";
#endif
			}
			switchToMSFS();
		}
		
		private void key1_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_1");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_1");
			}
		}
		private void key2_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_2");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_2");
			}
		}
		private void key3_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_3");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_3");
			}
		}
		private void key4_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_4");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_4");
			}
		}
		private void key5_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_5");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_5");
			}
		}
		private void key6_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_6");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_6");
			}
		}
		private void key7_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_7");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_7");
			}
		}
		private void key8_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_8");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_8");
			}
		}
		private void key9_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_9");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_9");
			}
		}
		private void key10_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_10");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_10");
			}
		}
		private void key11_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_11");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_11");
			}
		}
		private void key12_Click(object sender, EventArgs e)
		{
			if (eventMode == "MFD")
			{
				sendHver("H:AS1000_MFD_SOFTKEYS_12");
			}
			else
			{
				sendHver("H:AS1000_PFD_SOFTKEYS_12");
			}
		}
		private Point mouseLoc;
		private void frmMain_MouseDown(object sender, MouseEventArgs e)
		{
#if DEBUG
			debug_message.Text = "form_mousedown";
#endif
			mouseLoc = e.Location;
		}

		private void frmMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.lockPositionMenuItem.Checked == false)
				{
#if DEBUG
					debug_message.Text = "form_move";
#endif
					int dx = e.Location.X - mouseLoc.X;
					int dy = e.Location.Y - mouseLoc.Y;
					this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
				}
			}

		}
		private const int HTRIGHT = 11;

		Rectangle _Right { get { return new Rectangle(this.ClientSize.Width - 10, 0, 10, this.ClientSize.Height); } }
		protected override void WndProc(ref Message message)
		{
			base.WndProc(ref message);

			if (message.Msg == 0x84) // WM_NCHITTEST
			{
				var cursor = this.PointToClient(Cursor.Position);

				if (this.lockPositionMenuItem.Checked == false)
					if (_Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
			}
		}

		private void lockPositionMenuItem_Click(object sender, EventArgs e)
		{
			if (this.lockPositionMenuItem.Checked == true)
				this.lockPositionMenuItem.Checked = false;
			else
				this.lockPositionMenuItem.Checked = true;
		}
	}
}
