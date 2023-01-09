using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flippyBirdGame
{
    public partial class Form1 : Form
    {
        int gravity = 15;
        int pipeSpeed = 8;
        int gameScore = 0;
        int lifeCount = 3;
        int lifeFreeTime = 0;

        System.Media.SoundPlayer bye = new System.Media.SoundPlayer();
        System.Media.SoundPlayer die = new System.Media.SoundPlayer();
        System.Media.SoundPlayer getm = new System.Media.SoundPlayer();
        System.Media.SoundPlayer getheart = new System.Media.SoundPlayer();
        System.Media.SoundPlayer hit = new System.Media.SoundPlayer();
        System.Media.SoundPlayer playing = new System.Media.SoundPlayer();
        System.Media.SoundPlayer swoosh = new System.Media.SoundPlayer();

        public Form1()
        {
            InitializeComponent();

            bye.SoundLocation = "bye.wav";
            die.SoundLocation = "die.wav";
            getm.SoundLocation = "get.wav";
            getheart.SoundLocation = "getheart.wav";
            hit.SoundLocation = "hit.wav";
            playing.SoundLocation = "playing.wav";
            swoosh.SoundLocation = "swoosh.wav";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void GameTimeTikEvent(object sender, EventArgs e)
        {
            
            birdFadingEffect();
            lifeFreeTime += 20;
            pictureBox1.Top += gravity;
            pictureBox2.Left -= pipeSpeed;
            pictureBox3.Left -= pipeSpeed;
            pictureBox8.Left-= pipeSpeed;

            

            if (pictureBox2.Left < -150)
            {
                pictureBox2.Left = 750;
                gameScore++;
                getheart.Play();
                
            }
            if (pictureBox3.Left < -90)
            { 
                pictureBox3.Left = 850;
                gameScore++;
                getheart.Play();

            }

            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) || pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds) || pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                endGame();
            }

            if (pictureBox1.Bounds.IntersectsWith(pictureBox8.Bounds) && lifeCount <3)
            {
                extraLifeFunction();
               
            }

            if(pictureBox8.Left < -10)
            {
                pictureBox8.Left = 10000;
            }

            if (lifeCount == 1)
            {
                pictureBox5.Visible = true;
            }
            if (lifeCount == 2)
            {
                pictureBox6.Visible = true;
            }
            if (lifeCount == 3)
            {
                pictureBox7.Visible = true;
            }

            label1.Text = "Score:" + gameScore;
        }

        private void keyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) {
                gravity = 15;
            }
        }

        private void keyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void endGame()
        {
            if (lifeCount == 0 && lifeFreeTime > 1000)
            {
                timer1.Stop();
                label2.Text = "Game Over!!!\nYour Score: " + gameScore;
                label2.Visible = true;


                swoosh.Play();
                //end.Play();
            }
            else
            {
                switch (lifeCount)
                {
                    case 3:
                        if (lifeFreeTime > 2500) {
                            pictureBox7.Visible = false;
                            lifeCount--; 
                            lifeFreeTime = 0;
                            hit.Play();
                        }
                        break;
                    case 2:
                        if (lifeFreeTime > 2500)
                        {
                            pictureBox6.Visible = false;
                            lifeCount--;
                            lifeFreeTime = 0;
                            hit.Play();
                        }
                        break;
                    case 1:
                        if (lifeFreeTime > 2500)
                        {
                            pictureBox5.Visible = false;
                            lifeCount--;
                            lifeFreeTime = 0;
                            hit.Play();
                        }; 
                        break;
                }
            }

        }

        private void birdFadingEffect()
        {
            if (pictureBox1.Visible == true && lifeFreeTime < 1000)
            {
                pictureBox1.Visible = false;
            } else if (pictureBox1.Visible == false && lifeFreeTime < 1000)
            {
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = true;
            }
        }

        private void extraLifeFunction()
        {
            if(lifeCount < 3)
            {
                lifeCount++;
                pictureBox8.Left = 10000;
                getheart.Play();
            }
            
        }
    
    }
}
