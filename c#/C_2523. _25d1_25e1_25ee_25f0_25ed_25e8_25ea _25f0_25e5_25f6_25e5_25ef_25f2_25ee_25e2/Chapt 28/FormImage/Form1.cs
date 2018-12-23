using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace FormImage
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(88, 32);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		[Flags]
		private enum DrawingOptions
		{
			PRF_CHECKVISIBLE = 0x00000001,
			PRF_NONCLIENT = 0x00000002,
			PRF_CLIENT = 0x00000004,
			PRF_ERASEBKGND = 0x00000008,
			PRF_CHILDREN = 0x00000010,
			PRF_OWNED = 0x00000020
		}

		private const int WM_PRINT = 0x0317;
		private const int WM_PRINTCLIENT = 0x0318;

		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int msg, IntPtr dc,
			DrawingOptions opts);

		private void button1_Click(object sender, System.EventArgs e)
		{
			using (Bitmap bm = new Bitmap(Width + 2, Height + 2))
			{
				using (Graphics g = Graphics.FromImage(bm))
				{
					IntPtr dc = g.GetHdc();
					try
					{
						SendMessage(Handle, WM_PRINT, dc,
							DrawingOptions.PRF_CHILDREN |
							DrawingOptions.PRF_CLIENT |
							DrawingOptions.PRF_NONCLIENT);
					}
					finally
					{
						g.ReleaseHdc(dc);
					}
					bm.Save("bm.png");
				}
			}
		
		}
	}
}
