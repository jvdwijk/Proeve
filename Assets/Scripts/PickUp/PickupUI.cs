using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace PeppaSquad.Pickups
{
    public class PickupUI : MonoBehaviour
    {
        private PickupsHandler pickupsHandler;

        [SerializeField]
        private TextMeshProUGUI orangeAmountText, redAmountText, blueAmountText;

        [SerializeField]
        private Image yellowPickupOne, yellowPickupTwo, redPickupsOne, redPickupsTwo, bluePickupsOne, bluePickupsTwo;

        [SerializeField]
        private Sprite graySprite, yellowSprite, blueSprite, redSprite;

        public void OnMapChange(PickupsHandler handler){
            pickupsHandler = handler;
            pickupsHandler.OnDictChange += ChangeUI;
            ChangeUI();
        }

        private void ChangeUI(){
            UpdatePickupAmount();
            UpdateReadyPickups();
        }

        private void UpdatePickupAmount(){
            orangeAmountText.text = pickupsHandler.BoostTypeDict.ContainsKey(BoostType.Credits) ? pickupsHandler?.BoostTypeDict[BoostType.Credits].ToString() : "0";
            redAmountText.text = pickupsHandler.BoostTypeDict.ContainsKey(BoostType.Damage) ? pickupsHandler.BoostTypeDict[BoostType.Damage].ToString() : "0";
            blueAmountText.text = pickupsHandler.BoostTypeDict.ContainsKey(BoostType.Time) ? pickupsHandler.BoostTypeDict[BoostType.Time].ToString() : "0";
        }

        private void UpdateReadyPickups(){
            ChangeSprite(yellowPickupOne, yellowSprite, BoostType.Credits, 2);
            ChangeSprite(yellowPickupTwo, yellowSprite, BoostType.Credits, 3);
            
            ChangeSprite(redPickupsOne, redSprite, BoostType.Damage, 2);
            ChangeSprite(redPickupsTwo, redSprite, BoostType.Damage, 3);

            ChangeSprite(bluePickupsOne, blueSprite, BoostType.Time, 2);
            ChangeSprite(bluePickupsTwo, blueSprite, BoostType.Time, 3);
        }

        private void ChangeSprite(Image currentImage, Sprite enabledSprite, BoostType type, int amountNeeded = 1){
            if(!pickupsHandler.ReadyBoostsDict.ContainsKey(type)) {
                currentImage.sprite = graySprite;
                return;
            }
            currentImage.sprite = pickupsHandler.ReadyBoostsDict[type] >= amountNeeded ? enabledSprite : graySprite;
        }
    }
}