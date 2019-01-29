using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace joan_serrano
{
    public class BlindShot : IMiniGame
    {
        public GameManager gm;

        public Canvas gCan;

        public Image iZone, iTarget;
        public Sprite sActive, sDisabled, sWin, sLose;

        public bool started, pressed = false;

        public AudioClip[] fx;
        private AudioSource audioSource;

        public override void beginGame()
        {
            audioSource.clip = fx[0];
            audioSource.volume = 0.15f;
            audioSource.Play();
            started = true;
            gCan.enabled = true;
        }
        
        public override void initGame(MiniGameDificulty dificulty, GameManager gm)
        {
            audioSource = GetComponent<AudioSource>();
            gCan.enabled = false;
        }

        void Update()
        {
            RectTransform targetRect = iTarget.GetComponent<RectTransform>();
            if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4) && started)
            {
                
                iZone.sprite = sActive;

                RectTransform zoneRect = iZone.GetComponent<RectTransform>();
                if ((targetRect.position.x + 200) > (zoneRect.position.x) && (targetRect.position.x + 400) < (zoneRect.position.x + 400))
                {
                    iTarget.sprite = sWin;
                    StartCoroutine(EndWin());
                }
                else
                {
                    iTarget.sprite = sLose;
                    StartCoroutine(EndLose());
                }
            }

            if ((targetRect.position.x) > 2500){
                gm.EndGame(MiniGameResult.LOSE);
            }
        }

        public IEnumerator EndWin()
        {
            yield return new WaitForSeconds(0.2f);
            iZone.sprite = sDisabled;
            yield return new WaitForSeconds(2.5f);
            gm.EndGame(MiniGameResult.WIN);
        }
        public IEnumerator EndLose()
        {
            yield return new WaitForSeconds(0.2f);
            iZone.sprite = sDisabled;
            yield return new WaitForSeconds(2.5f);
            gm.EndGame(MiniGameResult.LOSE);
        }
    }
}

