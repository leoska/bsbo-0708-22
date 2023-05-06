namespace bsbo_0708_22
{
    public class Element
    {
        // Значения в нашем элементе
        public int value;
        // Указатель на следующий элемент
        public Element? next;

        // Базовый конструктор
        public Element(int value = 0, Element? next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

    public struct ElemValue
    {
        public int value;

        public ElemValue(int value = 0)
        {
            this.value = value;
        }
    }
}

