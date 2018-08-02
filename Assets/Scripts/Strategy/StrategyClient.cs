using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Strategy
{
    public class StrategyClient : MonoBehaviour
    {
        public InputField priceInput;
        public InputField countInput;
        public Dropdown calWay;

        public Text showLabel;
        public Text totalText;

        private float total;

        public void onBtnConfirmClick()
        {
            int price = int.Parse(priceInput.text);
            int count = int.Parse(countInput.text);
            CashStrategyContext csc = new CashStrategyContext(calWay.transform.Find("Label").GetComponent<Text>().text);

            float totalPrice = 0;
            totalPrice = csc.GetResult(price * count);
            total += totalPrice;
            showLabel.text = showLabel.text + "\n" + "单价：" + price + " 数量：" + count + " " +
                calWay.itemText.text + " 总计：" + totalPrice;
            totalText.text = total.ToString();
        }

        public void onBtnCanelClick()
        {
            
        }
    }
}
