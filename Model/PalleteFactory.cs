namespace Model {

    public class PalleteFactory<T> : IBaseContainerFactory<T> where T : BaseContainer {

        ///<summary>
        ///Возвращает контейнер типа Pallete.
        ///Все размеры указываются в метрах.
        ///Вес в кг.
        ///</summary>
        ///<param name="a">Глубина в м</param>
        ///<param name="b">Ширина в м</param>
        ///<param name="c">Высота в м</param>
        ///<param name="w">Вес в кг</param>
        ///<param name="date">Cрок годности если паллет не пустой</param>
        public T CreateContaner(float a, float b, float c, float w = 30, DateOnly date = default) {
            if (a <= 0 || b <= 0 || c <= 0 || w <= 0) {
                throw new Exception("Parametres must be positive!");
            }
            return (T) (new Pallete(a, b, c, w) as BaseContainer);
        }
    }
}