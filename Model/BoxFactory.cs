namespace Model {

    public class BoxFactory<T> : IBaseContainerFactory<T> where T : BaseContainer {

        ///<summary>
        ///Возвращает контейнер типа Box.
        ///Все размеры указываются в метрах.
        ///Вес в кг.
        ///Параметр даты устанавливается в дату производства если указана
        ///дата прошедшего/настойщего времени или в дату срока годности если будущего
        ///</summary>
        ///<param name="a">Глубина в м</param>
        ///<param name="b">Ширина в м</param>
        ///<param name="c">Высота в м</param>
        ///<param name="w">Вес в кг</param>
        ///<param name="date">Указание прошедшего/настоящего = дата производства. Будущего = срок годности</param>
        public T CreateContaner(float a, float b, float c, float w, DateOnly date) {
            if (a <= 0 || b <= 0 || c <= 0 || w <= 0 || date <= DateOnly.MinValue) {
                throw new Exception("Parametres must be positive!");
            }
            return (T) (new Box(a, b, c, w, date) as BaseContainer);
        }

        ///<summary>
        ///Возвращает контейнер типа Box.
        ///Все размеры указываются в метрах.
        ///Вес в кг.
        ///Параметр даты устанавливается в дату производства если указана
        ///дата прошедшего/настойщего времени или в дату срока годности если будущего
        ///</summary>
        ///<param name="a">Глубина в м</param>
        ///<param name="b">Ширина в м</param>
        ///<param name="c">Высота в м</param>
        ///<param name="w">Вес в кг</param>
        ///<param name="prodDate">Дата производства</param>
        ///<param name="suitDate">Срок годности</param>
        public T CreateContainer(float a, float b, int c, float w, DateOnly prodDate, DateOnly suitDate) {
            if (a <= 0 || b <= 0 || c <= 0 || w <= 0 || prodDate <= DateOnly.MinValue || suitDate <= DateOnly.MinValue) {
                throw new Exception("Parametres must be positive!");
            }
            return (T) (new Box(a, b, c, w, prodDate, suitDate) as BaseContainer);
        }
    }
}