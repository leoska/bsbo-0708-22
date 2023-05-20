namespace bsbo_0708_22
{
    public class ListElem
    {
        protected Element? Tail = null;

        // Проверяем пустой ли наш список
        public bool IsEmpty()
        {
            Program.N_OP += 1; 
            return Tail == null; // 1
        }

        // Добавляем элемент в конец списка
        public void Push(Element elem)
        {
            Program.N_OP += 2;
            if (!IsEmpty()) // 2
            {
                elem.next = Tail; // 2
                Program.N_OP += 2;
            }

            Tail = elem; // 1
            Program.N_OP += 1;
        }

        // Вытаскиваем элемент из конца списка
        public Element Pop()
        {
            Program.N_OP += 1;
            if (IsEmpty())
            {
                throw new Exception("ListElem is empty");
            }
            
            Element result = Tail; // 1

            Tail = Tail.next; // 2

            result.next = null; // 2

            Program.N_OP += 5;
            
            return result;
        }

        // Доступ к элементу по индексу
        protected virtual Element GetElemById(int index)
        {
            Element current = Tail;
            Program.N_OP += 1;

            Program.N_OP += 2;
            // 2
            for (int i = 0; i < index; i++) // 2 + 1
            {
                current = current.next; // 2

                if (current == null) // 1
                {
                    throw new Exception("ListElem out of range");
                }
                
                Program.N_OP += 6;
            }

            return current;
        }

        // Получаем int value по индексу в нашем списке
        public int Get(int index)
        {
            Program.N_OP += 4;
            Element result = GetElemById(index); // 3
            return result.value; // 1
        }

        // Перезаписываем int value по индексу в нашем списке
        public void Set(int index, int newValue)
        {
            Element result = GetElemById(index); // 3
            Program.N_OP += 5;
            result.value = newValue; // 2
        }

        // Вывод содержимого в консоль
        public void Print()
        {
            Element current = Tail;
            while (current != null)
            {
                Console.Write($"{current.value} ");
                current = current.next;
            }

            Console.WriteLine();
        }
        
        // Перегрузка оператора индексации []
        public int this[int index]
        {
            get
            {
                Program.N_OP += 2;
                return Get(index); // 2
            }
            set
            {
                Program.N_OP += 3;
                Set(index, value); // 3
            }
        }
    }
}

