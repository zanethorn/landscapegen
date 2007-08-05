using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using LandscapeGenCore;

namespace LandscapeGen
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelSideBar;
		private System.Windows.Forms.Panel panelViewArea;
		private System.Windows.Forms.Splitter splitterVert;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.Button buttonGenerate;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ComboBox cbRenderStyle;
		private System.Windows.Forms.Button buttonRandomGenerate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.PropertyGrid propertyGrid2;
		private System.Windows.Forms.Button buttonRender;

		private float[,] _ResultGrid = null;
		private PerlinNoise _perlinNoise;
		private KochLikeNoise _kochLikeNoise;
        private Button button1;
        private Button button2;
		private INoiseGenerator _noiseGen;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_perlinNoise = new PerlinNoise();
			_kochLikeNoise = new KochLikeNoise();
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
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.buttonRandomGenerate = new System.Windows.Forms.Button();
            this.cbRenderStyle = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.buttonRender = new System.Windows.Forms.Button();
            this.splitterVert = new System.Windows.Forms.Splitter();
            this.panelViewArea = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelSideBar.SuspendLayout();
            this.panelViewArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideBar
            // 
            this.panelSideBar.Controls.Add(this.button2);
            this.panelSideBar.Controls.Add(this.button1);
            this.panelSideBar.Controls.Add(this.propertyGrid2);
            this.panelSideBar.Controls.Add(this.propertyGrid1);
            this.panelSideBar.Controls.Add(this.buttonRandomGenerate);
            this.panelSideBar.Controls.Add(this.cbRenderStyle);
            this.panelSideBar.Controls.Add(this.buttonSave);
            this.panelSideBar.Controls.Add(this.buttonGenerate);
            this.panelSideBar.Controls.Add(this.cbType);
            this.panelSideBar.Controls.Add(this.buttonRender);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(248, 565);
            this.panelSideBar.TabIndex = 0;
            this.panelSideBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSideBar_Paint);
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid2.Location = new System.Drawing.Point(16, 344);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(216, 176);
            this.propertyGrid2.TabIndex = 20;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid1.Location = new System.Drawing.Point(16, 40);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(216, 232);
            this.propertyGrid1.TabIndex = 19;
            // 
            // buttonRandomGenerate
            // 
            this.buttonRandomGenerate.Location = new System.Drawing.Point(104, 280);
            this.buttonRandomGenerate.Name = "buttonRandomGenerate";
            this.buttonRandomGenerate.Size = new System.Drawing.Size(112, 23);
            this.buttonRandomGenerate.TabIndex = 18;
            this.buttonRandomGenerate.Text = "&Random Generate";
            // 
            // cbRenderStyle
            // 
            this.cbRenderStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRenderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRenderStyle.Items.AddRange(new object[] {
            "Green Plasma (Red-Green-Blue)",
            "Greyscale",
            "Clouds (Blue-White)",
            "Fire 1 (Orange-Red-Black)",
            "Fire 2 (Red-Orange-Black)",
            "Terran (banding)"});
            this.cbRenderStyle.Location = new System.Drawing.Point(8, 320);
            this.cbRenderStyle.Name = "cbRenderStyle";
            this.cbRenderStyle.Size = new System.Drawing.Size(232, 21);
            this.cbRenderStyle.TabIndex = 13;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(136, 528);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "&Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(16, 280);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.Text = "&Generate";
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // cbType
            // 
            this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Items.AddRange(new object[] {
            "Perlin noise",
            "Stochastic Koch curve"});
            this.cbType.Location = new System.Drawing.Point(8, 16);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(233, 21);
            this.cbType.TabIndex = 0;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // buttonRender
            // 
            this.buttonRender.Location = new System.Drawing.Point(24, 528);
            this.buttonRender.Name = "buttonRender";
            this.buttonRender.Size = new System.Drawing.Size(75, 23);
            this.buttonRender.TabIndex = 3;
            this.buttonRender.Text = "&Render";
            this.buttonRender.Click += new System.EventHandler(this.buttonRender_Click);
            // 
            // splitterVert
            // 
            this.splitterVert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitterVert.Location = new System.Drawing.Point(248, 0);
            this.splitterVert.Name = "splitterVert";
            this.splitterVert.Size = new System.Drawing.Size(8, 565);
            this.splitterVert.TabIndex = 1;
            this.splitterVert.TabStop = false;
            // 
            // panelViewArea
            // 
            this.panelViewArea.AutoScroll = true;
            this.panelViewArea.Controls.Add(this.pictureBox1);
            this.panelViewArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewArea.Location = new System.Drawing.Point(256, 0);
            this.panelViewArea.Name = "panelViewArea";
            this.panelViewArea.Size = new System.Drawing.Size(408, 565);
            this.panelViewArea.TabIndex = 2;
            this.panelViewArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelViewArea_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 544);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Title = "Save Image";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 512);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 565);
            this.Controls.Add(this.panelViewArea);
            this.Controls.Add(this.splitterVert);
            this.Controls.Add(this.panelSideBar);
            this.Name = "FormMain";
            this.Text = "Landscape Generator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelSideBar.ResumeLayout(false);
            this.panelViewArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void panelViewArea_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
		
		}

		private void FormMain_Load(object sender, System.EventArgs e) {
			this.cbType.SelectedIndex = 0;
			this.cbRenderStyle.SelectedIndex = 0;
		}



		private void Generate() {
			// Generate Noise Grid
			Cursor.Current = Cursors.WaitCursor;
			_ResultGrid = _noiseGen.Generate();
			Cursor.Current = Cursors.Default;
		}

		private void Render() {
			const float UPPERLIMIT = 10000;
			const float LOWERLIMIT = 0;

			if (_ResultGrid != null) {
				Normalize objNormal = new Normalize(UPPERLIMIT, LOWERLIMIT);
				float [,] scaledGrid = objNormal.Process(_ResultGrid);

				Render2D r2d = new Render2D();
				r2d.BoundsMax = UPPERLIMIT;
				r2d.BoundsMin = LOWERLIMIT;
				switch (this.cbRenderStyle.SelectedIndex) {
					case 0:
						this.pictureBox1.Image = r2d.RenderRainbow(scaledGrid);
						break;
					case 1:
						this.pictureBox1.Image = r2d.RenderGreyscale(scaledGrid);
						break;
					case 2:
						this.pictureBox1.Image = r2d.RenderClouds(scaledGrid);
						break;
					case 3:
						this.pictureBox1.Image = r2d.RenderFire(scaledGrid);
						break;
					case 4:
						this.pictureBox1.Image = r2d.RenderFire2(scaledGrid);
						break;
					case 5:
						this.pictureBox1.Image = r2d.RenderTerran(scaledGrid);
						break;
					default:
						MessageBox.Show("Unknown Render selected");
						break;
				}

				r2d.Free();
				r2d = null;
			} else {
				MessageBox.Show("No previously generated map grid!");
			}
		}

		private void buttonSave_Click(object sender, System.EventArgs e) {
			string sFile;
			if (saveFileDialog1.ShowDialog(this) == DialogResult.OK) {
				sFile = saveFileDialog1.FileName;
				pictureBox1.Image.Save(sFile);
			}

		}

		private void buttonGenerate_Click(object sender, System.EventArgs e) {
			Generate();
			Render();
		}

		private void buttonRender_Click(object sender, System.EventArgs e) {
			Render();
		}

		private void panelSideBar_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
		
		}

		private void cbType_SelectedIndexChanged(object sender, System.EventArgs e) {
			UpdateDisplay();
		}

		private void UpdateDisplay() {
			switch (cbType.SelectedIndex) {
				case 0:	//Perlin Noise
					_noiseGen = _perlinNoise;
					break;
				case 1:	//
					_noiseGen = _kochLikeNoise;
					break;
				default:
					_noiseGen = null;
					break;
			}

			if (_noiseGen != null) {
				propertyGrid1.SelectedObject = _noiseGen.Settings;
			} else {
				propertyGrid1.SelectedObject = null;
			}
		}

		private void pictureBox1_Click(object sender, System.EventArgs e) {
			if (pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage) 
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			else
				pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            const float UPPERLIMIT = 10000;
            const float LOWERLIMIT = 0;

            if (_ResultGrid != null)
            {
                Normalize objNormal = new Normalize(UPPERLIMIT, LOWERLIMIT);
                float[,] scaledGrid = objNormal.Process(_ResultGrid);

                Simple3d s3d = new Simple3d();
                //r2d.BoundsMax = UPPERLIMIT;
                //r2d.BoundsMin = LOWERLIMIT;
                this.pictureBox1.Image = s3d.Render(scaledGrid);

                s3d.Free();
                s3d = null;
            }
            else
            {
                MessageBox.Show("No previously generated map grid!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreeDSpace tds = new ThreeDSpace();

            tds.viewpoint = new ThreeDSpace.Point3D(-100, -100, -100, Color.Transparent);
            tds.screen = new ThreeDSpace.Point3D(0, 0, 0, Color.Transparent);

            //tds.pointObjects.Add(new ThreeDSpace.CubeObject(50, Color.PowderBlue));

            ThreeDSpace.MeshObject aMesh = new ThreeDSpace.MeshObject(4, 3, Color.Orange);
            aMesh.Scale = 32;
            tds.pointObjects.Add(aMesh); 

            tds.pointObjects.Add(new ThreeDSpace.LineObject(new ThreeDSpace.Point3D(-50, 0, 0, Color.Red), new ThreeDSpace.Point3D(50, 0, 0, Color.Red)));
            tds.pointObjects.Add(new ThreeDSpace.LineObject(new ThreeDSpace.Point3D(0, -50, 0, Color.Green), new ThreeDSpace.Point3D(0, 50, 0, Color.Green)));
            tds.pointObjects.Add(new ThreeDSpace.LineObject(new ThreeDSpace.Point3D(0, 0, -50, Color.Blue), new ThreeDSpace.Point3D(0, 0, 50, Color.Blue)));

            Bitmap bmp = new Bitmap(200, 200);

            const int offsetX = 100;
            const int offsetY = 100;
            SizeF sz = new SizeF(offsetX, offsetY);

            System.Drawing.Graphics g = Graphics.FromImage(bmp);
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            g.Clear(Color.White);

            //Draw lines
            foreach (ThreeDSpace.IPointObject po in tds.pointObjects)
            {
                foreach (ThreeDSpace.Lines3D l in po.Lines)
                {
                    //Draw line
                    
                    PointF start = tds.Render(l.Start);
                    PointF end = tds.Render(l.End);
                    start += sz;
                    end += sz;
                    g.DrawLine(new Pen(l.Start.color, 1), start, end);

                }
            }

            //Draw points
            foreach (ThreeDSpace.IPointObject po in tds.pointObjects) {
                foreach (ThreeDSpace.Point3D p in po.Points) {
                    PointF p2d = tds.Render(p);
                    p2d += sz;
                    if ((p2d.X > 0) && (p2d.X < bmp.Width) && (p2d.Y > 0) && (p2d.Y < bmp.Height))
                    {
                        bmp.SetPixel((int)Math.Round(p2d.X), (int)Math.Round(p2d.Y), p.color);
                    }
                }
            }

            g.Dispose();
            g = null;

            this.pictureBox1.Image = bmp;
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

	}
}
