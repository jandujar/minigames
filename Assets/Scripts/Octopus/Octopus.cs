using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace joan_serrano
{
    public class Octopus : IMiniGame
    {
        public GameManager gm;

        public Canvas gCan;

        public Image iBot, iBuild, iP1, iP2, iP3, tenta_0, tenta_1, tenta_2, tenta_3, tenta_4, tenta_5, tenta_6, tenta_7, tenta_8, tenta_9, tenta_10, tenta_11, tenta_12, tenta_13, tenta_14;
        public Image[] Tenta;
        public Sprite sIdle, sSIdle, sRun_0, sRun_1, sSRun_0, sSRun_1, sBuild_1, sBuild_2, sBuild_3, sWin, sLose;

        public bool started = false, got = false, hit = false;

        public int position = 0, build = 0, tent_1 = 1, tent_2 = 0, tent_3 = 1, tent_4 = 0, tent_5 = 1, rand = 0;
        public int[] Tent;

        public AudioClip[] fx;
        private AudioSource audioSource;

        public Button b_left;
        public Button b_right;

        public override void beginGame()
        {
            Tenta = new Image[15];
            Tenta[0] = tenta_0;
            Tenta[1] = tenta_1;
            Tenta[2] = tenta_2;
            Tenta[3] = tenta_3;
            Tenta[4] = tenta_4;
            Tenta[5] = tenta_5;
            Tenta[6] = tenta_6;
            Tenta[7] = tenta_7;
            Tenta[8] = tenta_8;
            Tenta[9] = tenta_9;
            Tenta[10] = tenta_10;
            Tenta[11] = tenta_11;
            Tenta[12] = tenta_12;
            Tenta[13] = tenta_13;
            Tenta[14] = tenta_14;

            Tent = new int[5];
            Tent[0] = tent_1;
            Tent[1] = tent_2;
            Tent[2] = tent_3;
            Tent[3] = tent_4;
            Tent[4] = tent_5;

            audioSource.clip = fx[0];
            audioSource.volume = 0.15f;
            audioSource.Play();
            started = true;
            gCan.enabled = true;

            Button btn_l = b_left.GetComponent<Button>();
            btn_l.onClick.AddListener(OnClickLeft);

            Button btn_r = b_right.GetComponent<Button>();
            btn_r.onClick.AddListener(OnClickRight);

            StartCoroutine(moveTentacles());
        }

        public override void initGame(MiniGameDificulty dificulty, GameManager gm)
        {
            audioSource = GetComponent<AudioSource>();
            gCan.enabled = false;
        }

        void Update()
        {
            if (started || !hit)
            {
                RectTransform botRect = iBot.GetComponent<RectTransform>();

                
                switch (position){
                    case 0:
                        if(build != 3)
                        {
                            iBot.sprite = sIdle;
                        }
                        botRect.anchoredPosition = new Vector2(-745, -125);

                        if (got == true)
                        {
                            build++;
                            got = false;

                            if (build == 1)
                            {
                                iBuild.enabled = true;
                                iBuild.sprite = sBuild_1;
                            }
                            if (build == 2)
                            {
                                iBuild.sprite = sBuild_2;
                            }
                            if (build == 3)
                            {
                                iBot.sprite = sWin;
                                iBuild.sprite = sBuild_3;
                                StartCoroutine(EndWin());
                            }
                        }
                        break;
                    case 1:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_0;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_0;
                            }
                        }

                        if(Tent[0] == 3)
                        {
                            hit = true;
                            iBot.sprite = sLose;
                            StartCoroutine(EndLose());
                        }

                        botRect.anchoredPosition = new Vector2(-650, -210);
                        break;
                    case 2:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_1;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_1;
                            }
                        }
                        botRect.anchoredPosition = new Vector2(-550, -275);
                        break;
                    case 3:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_0;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_0;
                            }
                        }

                        if (Tent[1] == 3)
                        {
                            hit = true;
                            iBot.sprite = sLose;
                            StartCoroutine(EndLose());
                        }

                        botRect.anchoredPosition = new Vector2(-370, -275);
                        break;
                    case 4:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_1;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_1;
                            }
                        }
                        botRect.anchoredPosition = new Vector2(-175, -275);
                        break;
                    case 5:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_0;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_0;
                            }
                        }

                        if (Tent[2] == 3)
                        {
                            hit = true;
                            iBot.sprite = sLose;
                            StartCoroutine(EndLose());
                        }

                        botRect.anchoredPosition = new Vector2(0, -275);
                        break;
                    case 6:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_1;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_1;
                            }
                        }
                        botRect.anchoredPosition = new Vector2(175, -275);
                        break;
                    case 7:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_0;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_0;
                            }
                        }

                        if (Tent[3] == 3)
                        {
                            hit = true;
                            iBot.sprite = sLose;
                            StartCoroutine(EndLose());
                        }

                        botRect.anchoredPosition = new Vector2(370, -275);
                        break;
                    case 8:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_1;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_1;
                            }
                        }
                        botRect.anchoredPosition = new Vector2(550, -275);
                        break;
                    case 9:
                        if (!hit)
                        {
                            if (!got)
                            {
                                iBot.sprite = sRun_0;
                            }
                            else if (got)
                            {
                                iBot.sprite = sSRun_0;
                            }
                        }

                        if (Tent[4] == 3)
                        {
                            hit = true;
                            iBot.sprite = sLose;
                            StartCoroutine(EndLose());
                        }

                        botRect.anchoredPosition = new Vector2(650, -210);
                        break;
                    case 10:
                        iBot.sprite = sSIdle;
                        botRect.anchoredPosition = new Vector2(745, -125);
                        if (got == false)
                        {
                            got = true;

                            if (build == 0)
                            {
                                iP1.enabled = false;
                            }
                            if (build == 1)
                            {
                                iP2.enabled = false;
                            }
                            if (build == 2)
                            {
                                iP3.enabled = false;
                            }
                        }
                        break;
                    default:
                        iBot.sprite = sIdle;
                        botRect.anchoredPosition = new Vector2(-745, -125);
                        break;
                }
                

            }
        }

        public IEnumerator EndWin()
        {
            iBot.sprite = sWin;
            yield return new WaitForSeconds(2.5f);
            gm.EndGame(MiniGameResult.WIN);
        }
        public IEnumerator EndLose()
        {
            iBot.sprite = sLose;
            yield return new WaitForSeconds(2.5f);
            gm.EndGame(MiniGameResult.LOSE);
        }

        private void OnClickLeft()
        {
            if (!hit)
            {
                position--;
                if (position <= 0)
                {
                    position = 0;
                }
            }
        }
        private void OnClickRight()
        {
            if (!hit)
            {
                position++;
                if (position >= 10)
                {
                    position = 10;
                }
            }
        }
         
        private IEnumerator moveTentacles()
        {
            int tent_count = 0;

            for (int i = 0; i < 15; i = i + 3)
            {
                rand = UnityEngine.Random.Range(0, 2);

                if (rand == 0)
                {
                    if (Tent[tent_count] == 0)
                    {
                        Tent[tent_count] = 0;
                    }
                    else if (Tent[tent_count] == 1)
                    {
                        Tent[tent_count] = 0;
                    }
                    else if (Tent[tent_count] == 2)
                    {
                        Tent[tent_count] = 1;
                    }
                    else if (Tent[tent_count] == 3)
                    {
                        Tent[tent_count] = 2;
                    }
                }
                else if (rand == 1)
                {
                    if (Tent[tent_count] == 0)
                    {
                        Tent[tent_count] = 1;
                    }
                    else if (Tent[tent_count] == 1)
                    {
                        Tent[tent_count] = 2;
                    }
                    else if (Tent[tent_count] == 2)
                    {
                        Tent[tent_count] = 3;
                    }
                    else if (Tent[tent_count] == 3)
                    {
                        Tent[tent_count] = 3;
                    }
                }

                if (Tent[tent_count] == 0)
                {
                    Tenta[i].enabled = false;
                    Tenta[i + 1].enabled = false;
                    Tenta[i + 2].enabled = false;
                }
                else if (Tent[tent_count] == 1)
                {
                    Tenta[i].enabled = true;
                    Tenta[i + 1].enabled = false;
                    Tenta[i + 2].enabled = false;
                }
                else if (Tent[tent_count] == 2)
                {
                    Tenta[i].enabled = true;
                    Tenta[i + 1].enabled = true;
                    Tenta[i + 2].enabled = false;
                }
                else if (Tent[tent_count] == 3)
                {
                    Tenta[i].enabled = true;
                    Tenta[i + 1].enabled = true;
                    Tenta[i + 2].enabled = true;
                }

                tent_count++;
            }


            yield return new WaitForSeconds(1.0f);
            StartCoroutine(moveTentacles());
        }
    }
}

