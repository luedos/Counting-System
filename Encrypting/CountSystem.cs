using System;
using System.Collections.Generic;
using System.Text;

namespace Encrypting
{
    
    public class CountSystem 
    {
        List<int> MyValue = new List<int>();
        int myOrder;

        int MyOrder {
            get { return myOrder; }

            set
            {
                int inOrder = value;
                if (inOrder > 45000)
                    inOrder = 45000;
                if (inOrder < 2)
                    inOrder = 2;

                CountSystem newOne = new CountSystem(inOrder);

                CountSystem retCS = new CountSystem(inOrder);

                for (int i = 0; i < MyValue.Count; ++i)
                {
                    newOne.MyValue.Clear();

                    newOne.MyValue.Add(MyValue[i]);

                    for (int ii = 0; ii < i; ++ii)
                        newOne.MultByInt(myOrder);

                    retCS.SelfSum(newOne);

                }

                MyValue = retCS.MyValue;

                myOrder = inOrder;
            }
        }



        private CountSystem()
        {
            myOrder = 10;
        }

        public CountSystem(int inMyOrder)
        {
            
            myOrder = inMyOrder;
            if (myOrder < 2)
                myOrder = 2;
            if (myOrder > 45000)
                myOrder = 45000;

           
        }

        public CountSystem(int inMyOrder, int inTenCS)
        {
            myOrder = inMyOrder;

            if (myOrder < 2)
                myOrder = 2;
            if (myOrder > 45000)
                myOrder = 45000;

            MyValue.Add(inTenCS);
            Normalize();

        }

        public CountSystem(int inMyOrder, List<int> inList)
        {
            myOrder = inMyOrder;

            if (myOrder < 2)
                myOrder = 2;
            if (myOrder > 45000)
                myOrder = 45000;

            SetValue(inList);
        }

        public CountSystem(CountSystem inCS)
        {
            myOrder = inCS.myOrder;
            SetValue(inCS.MyValue);
        }

        public void SetValue(CountSystem inCS)
        {
            CountSystem localCS = inCS;
            if (myOrder != inCS.myOrder)
                localCS = GetNewOrder(myOrder, inCS);

            MyValue.Clear();

            if (MyValue.Capacity < localCS.MyValue.Count)
                MyValue.Capacity = localCS.MyValue.Count;
            
            for (int i = 0; i < localCS.MyValue.Count; ++i)
                MyValue.Add(localCS.MyValue[i]);
        }

        private void SetValue(List<int> inList)
        {
            MyValue.Clear();

            if (MyValue.Capacity < inList.Count)
                MyValue.Capacity = inList.Count;

            for (int i = 0; i < inList.Count; ++i)
                MyValue.Add(inList[i]);

            Normalize();
        }
        
        public void Normalize()
        {
            

            for(int i = 0; i < MyValue.Count; ++i)
            {
                if (MyValue[i] >= myOrder || MyValue[i] <= -myOrder)
                {
                    int SomeInt = MyValue[i] / myOrder;
                    MyValue[i] -= myOrder * SomeInt;

                    if (i < MyValue.Count - 1)
                        MyValue[i + 1] += SomeInt;
                    else                  
                        MyValue.Add(SomeInt);                    
                }
            }

            for (int i = MyValue.Count - 1; i >= 0; --i)
                if (MyValue[i] == 0)
                    MyValue.RemoveAt(i);
                else
                    break;

            int count = MyValue.Count;

            if(MyValue.Count > 1)
            {
                if(MyValue[count - 1] < 0)
                    for(int i = count - 2; i >= 0; --i)
                        if(MyValue[i] > 0)
                        {
                            MyValue[i] -= myOrder;
                            ++MyValue[i + 1];
                        }

                if(MyValue[count - 1] > 0)
                    for(int i = count - 2; i >= 0; --i)
                        if(MyValue[i] < 0)
                        {
                            MyValue[i] += myOrder;
                            --MyValue[i + 1];
                        }
            }

            for (int i = count - 1; i > 0; --i)
                if (MyValue[i] == 0)
                    MyValue.RemoveAt(i);
                else
                    break;
        }

        public static void NormalizeList(List<int> inList, int inOrder)
        {
            int count = inList.Count;

            for (int i = 0; i < count; ++i)
            {
                if (inList[i] >= inOrder)
                {
                    int SomeInt = inList[i] / inOrder;
                    inList[i] -= inOrder * SomeInt;

                    if (i < count - 1)
                        inList[i + 1] += SomeInt;
                    else
                        inList.Add(SomeInt);
                }
            }

            for (int i = count - 1; i > 0; --i)
                if (inList[i] == 0)
                    inList.RemoveAt(i);
                else
                    break;

            count = inList.Count;

            if (inList.Count > 1)
            {
                if (inList[count - 1] < 0)
                    for (int i = count - 2; i >= 0; --i)
                        if (inList[i] > 0)
                        {
                            inList[i] -= inOrder;
                            ++inList[i + 1];
                        }

                if (inList[count - 1] > 0)
                    for (int i = count - 2; i >= 0; --i)
                        if (inList[i] < 0)
                        {
                            inList[i] += inOrder;
                            --inList[i + 1];
                        }
            }

            for (int i = count - 1; i > 0; --i)
                if (inList[i] == 0)
                    inList.RemoveAt(i);
                else
                    break;
        }

        private static void ListTenPow(List<int> inList, int TenthOrder)
        {
            if (TenthOrder <= 0)
                return;

             int count = inList.Count;

            if (inList.Capacity < count + TenthOrder)
                inList.Capacity = count + TenthOrder;


            for (int i = 0; i < TenthOrder; ++i)
                inList.Add(0);

            for (int i = count - 1; i >= 0; --i)
                inList[i + TenthOrder] = inList[i];

            for (int i = 0; i < TenthOrder; ++i)
                inList[i] = 0;

        }

        public void SelfTenPow(int TenthOrder)
        {
            if (TenthOrder <= 0)
                return;

            int count = MyValue.Count;

            if (MyValue.Capacity < count + TenthOrder)
                MyValue.Capacity = count + TenthOrder;

            for (int i = 0; i < TenthOrder; ++i)
                MyValue.Add(0);

            for (int i = count - 1; i >= 0; --i)
                MyValue[i + TenthOrder] = MyValue[i];

            for (int i = 0; i < TenthOrder; ++i)
                MyValue[i] = 0;
        }

        public int this[int inIndex]
        {
            get { return MyValue[inIndex]; }
            private set { MyValue[inIndex] = value; Normalize(); }
        }

        public static CountSystem GetNewOrder(int inOrder, CountSystem inCS)
        {
            if (inOrder > 45000)
                inOrder = 45000;
            if (inOrder < 2)
                inOrder = 2;

            CountSystem newOne = new CountSystem(inOrder);

            CountSystem retCS = new CountSystem(inOrder);

            for(int i = 0; i < inCS.MyValue.Count; ++i)
            {
                newOne.MyValue.Clear();

                newOne.MyValue.Add(inCS.MyValue[i]);

                for (int ii = 0; ii < i; ++ii)
                    newOne.MultByInt(inCS.myOrder);

                retCS.SelfSum(newOne);

            }

            return retCS;
        }


        /// <summary>
        /// Multiply Count System by integer
        /// </summary>
        /// <param name="inInt"> 
        /// Abs must be less then 45000! if not function will consider this number as +-45000 
        /// </param>
        public void MultByInt(int inInt)
        {
            if (inInt > 45000)
                inInt = 45000;
            if (inInt < -45000)
                inInt = -45000;

            for (int i = 0; i < MyValue.Count; ++i)
                MyValue[i] *= inInt;

            Normalize();
        }

       
        public static CountSystem operator + (CountSystem inCSfirst, CountSystem inCSsecond ) 
        {
            CountSystem retCS = new CountSystem(inCSfirst.myOrder);
            retCS.MyValue.Clear();

            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            for (int i = 0; i < inCSfirst.MyValue.Count && i < inSecond.MyValue.Count; ++i)
                retCS.MyValue.Add(inCSfirst.MyValue[i] + inSecond.MyValue[i]);

            if (inCSfirst.MyValue.Count > inSecond.MyValue.Count)
                for (int i = inSecond.MyValue.Count; i < inCSfirst.MyValue.Count; ++i)
                    retCS.MyValue.Add(inCSfirst.MyValue[i]);

            if (inCSfirst.MyValue.Count < inSecond.MyValue.Count)
                for (int i = inCSfirst.MyValue.Count; i < inSecond.MyValue.Count; ++i)
                    retCS.MyValue.Add(inSecond.MyValue[i]);

            retCS.Normalize();

            return retCS;
        }

        public static CountSystem operator * (CountSystem inCSfirst, CountSystem inCSsecond)
        {

            CountSystem TestCS = new CountSystem(inCSfirst.myOrder);


            CountSystem retCS = new CountSystem(inCSfirst.myOrder);

            CountSystem inSecond = inCSsecond;
            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            for(int i = 0; i < inSecond.MyValue.Count; ++i)
            {
                TestCS.SetValue(inCSfirst);

                for (int ii = 0; ii < TestCS.MyValue.Count; ++ii)
                    TestCS.MyValue[ii] *= inSecond.MyValue[i];

                TestCS.Normalize();

                TestCS.SelfTenPow(i);

                retCS.SelfSum(TestCS);


                
            }
            
            return retCS;
        }

        public static CountSystem operator - (CountSystem inCSfirst, CountSystem inCSsecond)
        {
            CountSystem retCS = new CountSystem(inCSfirst.myOrder);
            retCS.MyValue.Clear();

            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            for (int i = 0; i < inCSfirst.MyValue.Count && i < inSecond.MyValue.Count; ++i)
                retCS.MyValue.Add(inCSfirst.MyValue[i] - inSecond.MyValue[i]);

            if (inCSfirst.MyValue.Count > inSecond.MyValue.Count)
                for (int i = inSecond.MyValue.Count; i < inCSfirst.MyValue.Count; ++i)
                    retCS.MyValue.Add(inCSfirst.MyValue[i]);

            if (inCSfirst.MyValue.Count < inSecond.MyValue.Count)
                for (int i = inCSfirst.MyValue.Count; i < inSecond.MyValue.Count; ++i)
                    retCS.MyValue.Add(-inSecond.MyValue[i]);

            retCS.Normalize();

            return retCS;


        }

        public static CountSystem operator / (CountSystem inCSfirst, CountSystem inCSsecond)
        {
            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            CountSystem retCS = new CountSystem(inCSfirst.myOrder);

            CountSystem testCS = new CountSystem(inCSfirst.myOrder);

            CountSystem localCS = new CountSystem(inCSfirst.myOrder);


            for (int i = 1; i < inSecond.MyValue.Count; ++i)
                testCS.MyValue.Add(inCSfirst[inCSfirst.MyValue.Count - inSecond.MyValue.Count + i]);

            for(int i = inCSfirst.MyValue.Count - inSecond.MyValue.Count; i >= 0; --i)
            {
                testCS.MyValue.Insert(0, inCSfirst.MyValue[i]);

                if(testCS < inSecond)
                {
                    retCS.MyValue.Add(0);

                    continue;
                }
                else
                {
                    int Min = 1;
                    int Max = inCSfirst.myOrder;

                    int Mid = (Max + Min) / 2;

                    while (Max - Min > 1)
                    {

                        Mid = (Max + Min) / 2;

                        localCS.SetValue(inSecond);
                        localCS.MultByInt(Mid);

                        if (localCS <= testCS)
                        {
                            Min = Mid;
                            if (localCS == testCS)
                                break;
                        }
                        else
                        {
                            Max = Mid;
                        }
                    }

                    retCS.MyValue.Add(Min);

                    localCS.SetValue(inSecond);
                    localCS.MultByInt(Min);

                    testCS.SelfSub(localCS);
                }

            }

            retCS.MyValue.Reverse();

            retCS.Normalize();

            return retCS;

        }

        public void SelfSum(CountSystem inCS)
        {
            
            CountSystem localCS = inCS;

            if (myOrder != inCS.myOrder)
                localCS = GetNewOrder(myOrder, inCS);

            for (int i = 0; i < MyValue.Count && i < localCS.MyValue.Count; ++i)
                MyValue[i] += localCS.MyValue[i];

            if (MyValue.Count < localCS.MyValue.Count)
                for (int i = MyValue.Count; i < localCS.MyValue.Count; ++i)
                    MyValue.Add(localCS.MyValue[i]);

            Normalize();
        }

        public void SelfMul(CountSystem inCS)
        {
            CountSystem TestCS = new CountSystem(myOrder);


            CountSystem retCS = new CountSystem(myOrder);

            CountSystem inSecond = inCS;
            if (myOrder != inCS.myOrder)
                inSecond = GetNewOrder(myOrder, inCS);

            for (int i = 0; i < inSecond.MyValue.Count; ++i)
            {
                TestCS.SetValue(this);

                for (int ii = 0; ii < TestCS.MyValue.Count; ++ii)
                    TestCS.MyValue[ii] *= inSecond.MyValue[i];

                TestCS.Normalize();

                TestCS.SelfTenPow(i);

                retCS.SelfSum(TestCS);

            }

            MyValue = retCS.MyValue;
        }

        public void SelfSub(CountSystem inCS)
        {
            CountSystem localCS = inCS;

            if (myOrder != inCS.myOrder)
                localCS = GetNewOrder(myOrder, inCS);

            for (int i = 0; i < MyValue.Count && i < localCS.MyValue.Count; ++i)
                MyValue[i] -= localCS.MyValue[i];            

            if (MyValue.Count < localCS.MyValue.Count)
                for (int i = MyValue.Count; i < localCS.MyValue.Count; ++i)
                    MyValue.Add(-localCS.MyValue[i]);

            Normalize();
        }

        public void SelfDiv(CountSystem inCS)
        {
            CountSystem inSecond = inCS;

            if (myOrder != inCS.myOrder)
                inSecond = GetNewOrder(myOrder, inCS);

            CountSystem retCS = new CountSystem(myOrder);

            CountSystem testCS = new CountSystem(myOrder);

            CountSystem localCS = new CountSystem(myOrder);

           for (int i = 1; i < inSecond.MyValue.Count; ++i)
                testCS.MyValue.Add(MyValue[MyValue.Count - inSecond.MyValue.Count + i]);

            for(int i = MyValue.Count - inSecond.MyValue.Count; i >= 0; --i)            
            {
                testCS.MyValue.Insert(0, MyValue[i]);

                if (testCS < inSecond)
                {
                    retCS.MyValue.Add( 0);

                    continue;
                }
                else
                {
                    int Min = 1;
                    int Max = myOrder;

                    while (Max - Min > 1)
                    {
                        int Mid = (Max + Min) / 2;

                        localCS.SetValue(inSecond);
                        localCS.MultByInt(Mid);

                        if (localCS <= testCS)
                        {
                            Min = Mid;
                            if (localCS == testCS)
                                break;
                        }
                        else
                            Max = Mid;

                    }


                    localCS.SetValue(inSecond);
                    localCS.MultByInt(Min);

                    testCS.SelfSub(localCS);

                    retCS.MyValue.Add(Min);
                }

            }
            retCS.MyValue.Reverse();

            retCS.Normalize();

            MyValue = retCS.MyValue;
        }


        public static bool operator == (CountSystem inCSfirst, CountSystem inCSsecond)
        {
            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            if (inCSfirst.MyValue.Count != inSecond.MyValue.Count)
                return false;

            for (int i = 0; i < inCSfirst.MyValue.Count; ++i)
                if (inCSfirst.MyValue[i] != inSecond.MyValue.Count)
                    return false;

            return true;

        }

        public static bool operator !=(CountSystem inCSfirst, CountSystem inCSsecond)
        {
            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            if (inCSfirst.MyValue.Count != inSecond.MyValue.Count)
                return true;

            for (int i = 0; i < inCSfirst.MyValue.Count; ++i)
                if (inCSfirst.MyValue[i] != inSecond.MyValue.Count)
                    return true;

            return false;

        }

        public static bool operator >(CountSystem inCSfirst, CountSystem inCSsecond)
        {
            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            if (inCSfirst.MyValue.Count > inSecond.MyValue.Count)
                return inCSfirst.MyValue[inCSfirst.MyValue.Count - 1] > 0;

            if (inCSfirst.MyValue.Count < inSecond.MyValue.Count)
                return inSecond.MyValue[inSecond.MyValue.Count - 1] < 0;


            for(int i = inCSfirst.MyValue.Count - 1; i >= 0; --i)
            {
                if (inCSfirst.MyValue[i] == inSecond.MyValue[i])
                    continue;

                if (inCSfirst.MyValue[i] > inSecond.MyValue[i])
                    return true;

                if (inCSfirst.MyValue[i] < inSecond.MyValue[i])
                    return false;
            }

            return false;
        }

        public static bool operator < (CountSystem inCSfirst, CountSystem inCSsecond)
        {
            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            if (inCSfirst.MyValue.Count > inSecond.MyValue.Count)
                return inCSfirst.MyValue[inCSfirst.MyValue.Count - 1] < 0;


            if (inCSfirst.MyValue.Count < inSecond.MyValue.Count)
                return inSecond.MyValue[inSecond.MyValue.Count - 1] > 0;


            for (int i = inCSfirst.MyValue.Count - 1; i >= 0; --i)
            {
                if (inCSfirst.MyValue[i] == inSecond.MyValue[i])
                    continue;

                if (inCSfirst.MyValue[i] > inSecond.MyValue[i])
                    return false;

                if (inCSfirst.MyValue[i] < inSecond.MyValue[i])
                    return true;
            }

            return false;
        }

        public static bool operator >=(CountSystem inCSfirst, CountSystem inCSsecond)
        {
            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            if (inCSfirst.MyValue.Count > inSecond.MyValue.Count)
                return inCSfirst.MyValue[inCSfirst.MyValue.Count - 1] > 0;


            if (inCSfirst.MyValue.Count < inSecond.MyValue.Count)
                return inSecond.MyValue[inSecond.MyValue.Count - 1] < 0;


            for (int i = inCSfirst.MyValue.Count - 1; i >= 0; --i)
            {
                if (inCSfirst.MyValue[i] == inSecond.MyValue[i])
                    continue;

                if (inCSfirst.MyValue[i] > inSecond.MyValue[i])
                    return true;

                if (inCSfirst.MyValue[i] < inSecond.MyValue[i])
                    return false;
            }

            return true;
        }

        public static bool operator <=(CountSystem inCSfirst, CountSystem inCSsecond)
        {
            CountSystem inSecond = inCSsecond;

            if (inCSfirst.myOrder != inCSsecond.myOrder)
                inSecond = GetNewOrder(inCSfirst.myOrder, inCSsecond);

            if (inCSfirst.MyValue.Count > inSecond.MyValue.Count)
                return inCSfirst.MyValue[inCSfirst.MyValue.Count - 1] < 0;


            if (inCSfirst.MyValue.Count < inSecond.MyValue.Count)
                return inSecond.MyValue[inSecond.MyValue.Count - 1] > 0;


            for (int i = inCSfirst.MyValue.Count - 1; i >= 0; --i)
            {
                if (inCSfirst.MyValue[i] == inSecond.MyValue[i])
                    continue;

                if (inCSfirst.MyValue[i] > inSecond.MyValue[i])
                    return false;

                if (inCSfirst.MyValue[i] < inSecond.MyValue[i])
                    return true;
            }

            return true;
        }

        

        public override int GetHashCode()
        {
            int TestInt = 0;
            unchecked
            {
                for (int i = 0; i < MyValue.Count; ++i)
                    TestInt += MyValue[i];
            }
            return TestInt;
        }

        public override bool Equals(object obj)
        {
            CountSystem TestCS = obj as CountSystem;

            if (TestCS == null)
                return false;

            return this == TestCS;
        }

        public override string ToString()
        {
            if (MyValue.Count == 0)
                return String.Empty;

            StringBuilder sb = new StringBuilder(MyValue[MyValue.Count - 1].ToString());

            for (int i = MyValue.Count - 2; i >= 0; --i)
                sb.Append("." + MyValue[i].ToString());

            sb.Append("(" + myOrder.ToString() + ")");

            return sb.ToString();

        }

    }

    
}
