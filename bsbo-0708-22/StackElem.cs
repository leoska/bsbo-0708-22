namespace bsbo_0708_22
{
    public class StackElem: ListElem
    {
        // Временный стэк, для временного хранения элементов, когда обращаемся по индексу
        public static StackElem tmp = new StackElem();

        // Возвращаем все из временного стэка в наш стэк
        private void ReturnFromTMP()
        {
            while(!tmp.IsEmpty())
                Push(tmp.Pop());
        }
        
        // Перегружаем доступ к элементу по индексу в стэке
        protected override Element GetElemById(int index)
        {
            if (IsEmpty())
            {
                throw new Exception("StackElem is empty");
            }

            for (int i = 0; i < index; i++)
            {
                tmp.Push(Pop());

                if (IsEmpty())
                {
                    ReturnFromTMP();
                    
                    throw new Exception("StackElem out of range");
                }
            }

            Element result = Tail;
            
            ReturnFromTMP();

            return result;
        }
    }
}

