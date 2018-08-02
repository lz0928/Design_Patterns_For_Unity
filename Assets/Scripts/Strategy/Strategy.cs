using System;
using UnityEngine;

namespace Assets.Scripts.Strategy
{

    public class CashStrategyContext
    {
        CashSuper cs;
        public CashStrategyContext(string type)
        {
            switch (type)
            {
                case "正常收费":
                    cs = new CashNormal();
                    break;
                case "满300减100":
                    cs = new CashReturn(300, 100);
                    break;
                case "打八折":
                    cs = new CashRebate(0.8f);
                    break;
                default:
                    Debug.LogWarning("type:" + type);
                    break;
            }
        }

        public float GetResult(float money)
        {
            return cs.acceptCash(money);
        }
    }

    /// <summary>
    /// 收费抽象类
    /// </summary>
    public abstract class CashSuper
    {
        public abstract float acceptCash(float money);
    }
    
    public class CashNormal : CashSuper
    {
        public override float acceptCash(float money)
        {
            return money;
        }
    }

    public class CashRebate : CashSuper
    {
        private float m_retate;
        public CashRebate(float rebate)
        {
            m_retate = rebate;
        }
        public override float acceptCash(float money)
        {
            return m_retate * money;
        }
    }

    public class CashReturn : CashSuper
    {
        private float monoeyCondition;
        private float moneyReturn;

        public CashReturn(float condition, float mreturn)
        {
            monoeyCondition = condition;
            moneyReturn = mreturn;
        }
        public override float acceptCash(float money)
        {
            float result = money;
            if(money >= monoeyCondition)
            {
                result = money - (float)Math.Floor(money / monoeyCondition) * moneyReturn;
            }
            return result;
        }
    }
}
