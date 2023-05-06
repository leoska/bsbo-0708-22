namespace bsbo_0708_22
{
    public class ListElem
    {
        protected Element? Tail = null;

        // Проверяем пустой ли наш список
        public bool IsEmpty()
        {
            return Tail == null;
        }

        // Добавляем элемент в конец списка
        public void Push(Element elem)
        {
            if (!IsEmpty())
            {
                elem.next = Tail;
            }

            Tail = elem;
        }

        // Вытаскиваем элемент из конца списка
        public Element Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("ListElem is empty");
            }

            Element result = Tail;

            Tail = Tail.next;

            result.next = null;

            return result;
        }

        // Доступ к элементу по индексу
        protected virtual Element GetElemById(int index)
        {
            Element current = Tail;

            for (int i = 0; i < index; i++)
            {
                current = current.next;

                if (current == null)
                {
                    throw new Exception("ListElem out of range");
                }
            }

            return current;
        }

        // Получаем int value по индексу в нашем списке
        public int Get(int index)
        {
            Element result = GetElemById(index);
            return result.value;
        }

        // Перезаписываем int value по индексу в нашем списке
        public void Set(int index, int newValue)
        {
            Element result = GetElemById(index);
            result.value = newValue;
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
            get => Get(index);
            set => Set(index, value);
        }
    }
}

