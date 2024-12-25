using QuickSortAlgorithm;
namespace StackAlgorithm
{
    public class Stack
    {
        private int[] stack;
        private int _size = -1;
        public Stack(int size = 1)
        {
            stack = new int[size];
        }
        private static void ResizeArr(ref int[] arr)
        {
            int[] newArr = new int[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }

        /// <summary>
        /// Добавляет элемент в массив
        /// </summary>
        /// <param name="number"></param>
        public void Push(int number)
        {
            if (FullStack())
            {
                ResizeArr(ref stack);
                Push(number);
            }
            else { stack[++_size] = number; }

        }

        /// <summary>
        /// Выводит стек на консоль
        /// </summary>
        /// <param name="stack"></param>
        public static void ShowStack(Stack stack)
        {
            if (stack.EmptyStack())
            {
                Console.WriteLine("Stack is empty");
            }
            for (int i = stack.stack.Length - 1; i >= 0; i--)
            {
                Console.Write($"{stack.stack[i]} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Проверяет пуст ли стек, и возвращает булевое значение
        /// </summary>
        /// <returns></returns>
        public bool EmptyStack()
        {
            bool isEmpty = false;

            if (_size == -1 || stack.Length == 0) return true;

            return isEmpty;
        }

        /// <summary>
        /// Проверяет полон ли стек, и возвращает булевое значение
        /// </summary>
        /// <returns></returns>
        public bool FullStack()
        {
            bool isFull = false;

            if (_size == stack.Length - 1) return true;

            return isFull;
        }

        /// <summary>
        /// Извлекает и возвращает первый элемент из стека
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            int number = -1;
            if (EmptyStack())
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                number = stack[_size];
                int[] tempArr = new int[stack.Length - 1];

                for (int i = 0; i < stack.Length - 1; i++)
                {
                    tempArr[i] = stack[i];
                }

                stack = new int[stack.Length - 1];

                _size = -1;

                for (int i = 0; i < tempArr.Length; i++)
                {
                    Push(tempArr[i]);
                }
            }


            return number;
        }

        /// <summary>
        /// Возвращает первый элемент из стека 
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            int number = -1;
            if (EmptyStack())
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                number = stack[_size];
            }
            return number;
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="stack"></param>
        public static void SortDescending(Stack stack)
        {
            QuickSort.Sort(stack.stack, 0, stack.stack.Length - 1);
        }

        /// <summary>
        /// Сортирует элементы массива по возрастанию
        /// </summary>
        /// <param name="stack"></param>
        public static void SortAscending(Stack stack)
        {
            for (int i = 0; i < stack.stack.Length; i++)
            {
                for (int j = i + 1; j < stack.stack.Length; j++)
                {
                    if (stack.stack[i] < stack.stack[j])
                    {
                        (stack.stack[i], stack.stack[j]) = (stack.stack[j], stack.stack[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает перевернутый стек
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static Stack Reverse(Stack stack)
        {
            var stack2 = new Stack();

            for (int i = stack.stack.Length; i > 0; i--)
            {
                stack2.Push(stack.Pop());
            }

            return stack2;
        }

        /// <summary>
        /// Возвоащает наибольший эелемент
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static int MaxElement(Stack stack)
        {
            int max = stack.stack[0];
            for (int i = 1; i < stack.stack.Length; i++)
            {
                if (stack.stack[i] > max)
                {
                    max = stack.stack[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Возвоащает минимальный эелемент
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static int MinElement(Stack stack)
        {
            int min = stack.stack[0];
            for (int i = 1; i < stack.stack.Length; i++)
            {
                if (stack.stack[i] < min)
                {
                    min = stack.stack[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Удаляет весь стек
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static void Clear(Stack stack)
        {
            for (int i = stack.stack.Length; i > 0; i--)
            {
                stack.Pop();
            }
        }

        /// <summary>
        /// Удаляет указанный элемент массива
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void RemoveElement(Stack stack, int value)
        {
            var newStack = new Stack();
            for (int i = stack.stack.Length - 1; i >= 0; i--)
            {
                if (stack.stack[i] == value)
                {
                    stack.Pop();
                    continue;
                }

                newStack.Push(stack.Pop());
            }

            for (int i = newStack.stack.Length; i > 0; i--)
            {
                stack.Push(newStack.Pop());
            }
        }

        /// <summary>
        ///
        ///Возвращает длину стека
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static int Count(Stack stack)
        {
            return stack.stack.Length;
        }

        /// <summary>
        /// Возвоащает кол-во элементов числа, в массиве
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Count(Stack stack, int number)
        {
            int count = 0;
            for (int i = 0; i < stack.stack.Length; i++)
            {
                if (stack.stack[i] == number) count++;
            }

            return count;
        }

        /// <summary>
        /// Возвоащает находится ли элемент в массиве
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool Contains(Stack stack, int number)
        {
            bool isContains = false;
            for (int i = 0; i < stack.stack.Length; i++)
            {
                if (stack.stack[i] == number) isContains = true;
            }

            return isContains;
        }

        /// <summary>
        /// Убирает повторяющиеся элементы массива
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static void Distinct(Stack stack)
        {
            HashSet<int> hashSet = new HashSet<int>();

            for (int i = stack.stack.Length; i > 0; i--)
            {
                hashSet.Add(stack.Pop());
            }

            foreach (var item in hashSet.Reverse())
            {
                stack.Push(item);
            }
        }

        /// <summary>
        /// Возвоащает верхний элемент стэка
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static int GetTopElement(Stack stack)
        {
            int topIndex = Count(stack) - 1;
            int bottomElement = stack.stack[topIndex];
            return bottomElement;
        }

        /// <summary>
        /// Возвоащает нижний элемент стэка
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static int GetBottomElement(Stack stack)
        {
            int topElement = stack.stack[0];
            return topElement;
        }

        /// <summary>
        /// Поворачивает все элементы в лево на заданное вращение
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="rotation"></param>
        public static void RotateLeft(Stack stack, int rotation)
        {
            var stackRotationToLeft = new Stack();

            for (int i = 0; i < rotation; i++)
            {
                int temp = stack.Pop();
                for (int j = stack.stack.Length; j > 0; j--)
                {
                    stackRotationToLeft.Push(stack.Pop());
                }

                stackRotationToLeft.Push(temp);
                for (int j = stackRotationToLeft.stack.Length; j > 0; j--)
                {
                    stack.Push(stackRotationToLeft.Pop());
                }
            }
        }

        /// <summary>
        /// Меняет местами два верхних элемента
        /// </summary>
        /// <param name="stack"></param>
        public static void SwapTopTwoElements(Stack stack)
        {
            int firstNumber = stack.stack.Length - 1;
            int secondNumber = Count(stack) - 2;

            (stack.stack[firstNumber], stack.stack[secondNumber]) = (stack.stack[secondNumber], stack.stack[firstNumber]);
        }

        /// <summary>
        /// Возвращает индекс веденного числа
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetIndexValue(Stack stack, int value)
        {
            int index = 0;

            var stack2 = new Stack();
            for (int i = stack.stack.Length; i > 0; i--)
            {
                stack2.Push(stack.Pop());
            }

            for (int i = stack2.stack.Length - 1; i > 0; i--)
            {
                if (stack2.stack[i] == value)
                {
                    index = i;
                }
            }

            for (int i = stack2.stack.Length; i > 0; i--)
            {
                stack.Push(stack2.Pop());
            }

            return index + 1;
        }

        /// <summary>
        /// Возвоащает два объедененных стека
        /// </summary>
        /// <param name="stack1"></param>
        /// <param name="stack2"></param>
        /// <returns></returns>
        public static Stack MergeStacks(Stack stack1, Stack stack2)
        {
            //в новый стек помещается два передеаваемавыема......
            var mergedStack = new Stack();
            for (int i = stack1.stack.Length; i > 0; i--)
            {
                mergedStack.Push(stack1.Pop());
            }

            for (int i = stack2.stack.Length; i > 0; i--)
            {
                mergedStack.Push(stack2.Pop());
            }

            return mergedStack;
        }

        /// <summary>
        /// Проверяет является ли stack2 подмножеством stack1
        /// </summary>
        /// <param name="stack1"></param>
        /// <param name="stack2"></param>
        /// <returns></returns>
        public static bool IsSubset(Stack stack1, Stack stack2)
        {
            if (stack1.stack.Length < stack2.stack.Length) return true;
            bool isSubset = true;
            int count = 1;

            int i = 0;
            while (i < stack1.stack.Length)
            {
                for (int j = 0; j < stack2.stack.Length; j++)
                {
                    if (stack1.stack[i] == stack2.stack[j])
                    {
                        count++;
                        i++;
                    }
                    else
                    {
                        i++;
                        j = 0;
                        count = 1;
                    }

                    if (count == stack2.stack.Length) return false;
                }
            }

            return isSubset;
        }

        /// <summary>
        /// Проверяет на равенство двух стеков
        /// </summary>
        /// <param name="stack1"></param>
        /// <param name="stack2"></param>
        /// <returns></returns>
        public static bool EqualStack(Stack stack1, Stack stack2)
        {
            bool isEqual = true;
            if (stack1.stack.Length != stack2.stack.Length) return false;

            for (int i = 0; i < stack1.stack.Length; i++)
            {
                for (int j = 0; j < stack1.stack.Length; j++)
                {
                    if (stack1.stack[i] != stack2.stack[j]) return false;
                    i++;
                }
            }

            return isEqual;
        }

        /// <summary>
        /// возвращает стек, состоящий из одинаковых значений указанных стеков
        /// </summary>
        /// <param name="stack1"></param>
        /// <param name="stack2"></param>
        /// <returns></returns>
        public static Stack Common(Stack stack1, Stack stack2)
        {
            var commonStack = new Stack();

            for (int i = 0; i < stack1.stack.Length; i++)
            {
                for (int j = 0; j < stack2.stack.Length; j++)
                {
                    if (stack1.stack[i] == stack2.stack[j]) commonStack.Push(stack1.stack[i]);
                }
            }

            return commonStack;
        }
        /// <summary>
        /// Возвращает стек, в котором есть в первом стеке, но отсутсвуют во втором
        /// </summary>
        /// <param name="stack1"></param>
        /// <param name="stack2"></param>
        /// <returns></returns>
        public static Stack Diff(Stack stack1, Stack stack2)
        {
            var commonStack = new Stack();
            bool check = false;
            for (int i = 0; i < stack1.stack.Length; i++)
            {
                for (int j = 0; j < stack2.stack.Length; j++)
                {
                    if (stack1.stack[i] != stack2.stack[j])
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
                if (check) commonStack.Push(stack1.stack[i]);
            }

            return commonStack;
        }

        /// <summary>
        /// Соединяет два стека без повторяющийся элементов
        /// </summary>
        /// <param name="stack1"></param>
        /// <param name="stack2"></param>
        /// <returns></returns>
        public static Stack ConcatDistinct(Stack stack1, Stack stack2)
        {
            var stackConcatDisting = new Stack();

            for (int i = 0; i < stack1.stack.Length; i++)
            {
                stackConcatDisting.Push(stack1.stack[i]);
            }

            for (int i = 0; i < stack2.stack.Length; i++)
            {
                stackConcatDisting.Push(stack2.stack[i]);
            }

            Distinct(stackConcatDisting);

            return stackConcatDisting;
        }

        /// <summary>
        /// Возвращает стек, симметрическую разность множеств
        /// </summary>
        /// <param name="stack1"></param>
        /// <param name="stack2"></param>
        /// <returns></returns>
        public static Stack SymmetricalDifference(Stack stack1, Stack stack2)
        {
            var symmetricalDifference = new Stack();
            bool check = true;

            for (int i = 0; i < stack1.stack.Length; i++)
            {
                for (int j = 0; j < stack2.stack.Length; j++)
                {
                    if (stack1.stack[i] == stack2.stack[j])
                    {
                        check = false;
                        break;
                    }
                    else { check = true; }
                }
                if (check) symmetricalDifference.Push(stack1.stack[i]);
            }

            for (int i = 0; i < stack2.stack.Length; i++)
            {
                for (int j = 0; j < stack1.stack.Length; j++)
                {
                    if (stack2.stack[i] == stack1.stack[j])
                    {
                        check = false;
                        break;
                    }
                    else { check = true; }
                }
                if (check) symmetricalDifference.Push(stack2.stack[i]);
            }

            return symmetricalDifference;
        }

        /// <summary>
        /// возвращает список элементов, начиная с индекса firstIndex, заканчивая индексом lastIndex
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="firstIndex"></param>
        /// <param name="lastIndex"></param>
        /// <returns></returns>
        public static Stack GetRange(Stack stack, int firstIndex, int lastIndex)
        {
            var
            getRange = new Stack();

            try
            {
                for (int i = firstIndex; i < lastIndex + 1; i++)
                {
                    getRange.Push(stack.stack[i]);
                }
            }
            catch
            {
                Console.WriteLine("Неверное указан диапозон индексов");
                return null;
            }

            return getRange;
        }

        /// <summary>
        /// Возращает булевое значение, от лябды выражения (проврка на четность стека: x => x % 2 == 0)
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool LambdaStack(Stack stack, Func<int, bool> func)
        {
            for (int i = 0; i < stack.stack.Length; i++)
            {
                if (!func(stack.stack[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Проверяет соответвует ли хотябы один элемент стека условию
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool Any(Stack stack, Func<int, bool> func)
        {
            for (int i = 0; i < stack.stack.Length; i++)
            {
                if (func(stack.stack[i])) return true;
            }
            return false;
        }

        /// <summary>
        /// Удаляет элементы стека, которые не соотвествуют условию
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="func"></param>
        public static void RemoveCertain(Stack stack, Func<int, bool> func)
        {
            var correctedStack = new Stack();

            for (int i = 0; i < stack.stack.Length; i++)
            {
                if (!func(stack.stack[i]))
                {
                    RemoveElement(stack, stack.stack[i]);
                }
            }
        }
    }
}
