namespace HD.Model
{
    public interface IIssueState
    {
        /// <summary>
        /// Перевести в работу
        /// </summary>
        void Work();

        /// <summary>
        /// Закрыть
        /// </summary>
        void Close();

        /// <summary>
        /// Отказать в исполнении
        /// </summary>
        void Reject();

        /// <summary>
        /// Выполнена
        /// </summary>
        void Done();

    }
}