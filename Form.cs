﻿using System;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool isPaused = false;

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Text = "Game of Life";
            bStop.Enabled = false;
            bStop.Text = "Pause";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                bStart.Enabled = false;
                ResumeGame();

                SetPaused();
            } else
            {
                bStop.Enabled = true;
                StartGame();
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            SetPaused();

            if (isPaused)
            {
                bStart.Enabled = true;
                StopGame();
            }
            else
            {
                bStop.Enabled = false;
                PauseGame();
            }
        }

        private void gameContent_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer.Enabled) return;

            if (e.Button == MouseButtons.Left)
                SetOnMousePos(e.Location.X, e.Location.Y, true);
            else if (e.Button == MouseButtons.Right)
                SetOnMousePos(e.Location.X, e.Location.Y, false);
        }

        private void StartGame()
        {
            if (timer.Enabled) return;

            nudResolution.Enabled = false;
            nudDensity.Enabled = false;

            InitGame();

            timer.Start();
        }

        private void PauseGame()
        {
            timer.Stop();
        }

        private void StopGame()
        {
            timer.Stop();

            nudResolution.Enabled = true;
            nudDensity.Enabled = true;
        }

        private void ResumeGame()
        {
            timer.Start();
        }

        private void SetPaused()
        {
            if (isPaused)
            {
                bStop.Text = "Pause";
                bStart.Text = "Start";

                isPaused = false;
            } else
            {
                bStop.Text = "Stop";
                bStart.Text = "Resume";

                isPaused = true;
            }
        }
    }
}
