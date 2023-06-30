namespace Model {

    public interface ICompactable {
        public DateOnly ProdDate { get; }
        public DateOnly SuitDate { get; set; }
        public float Volume { get; }
        public float Weight { get; }
    }
}