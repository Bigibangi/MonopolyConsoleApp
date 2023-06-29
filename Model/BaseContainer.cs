namespace Model {

    public abstract class BaseContainer {
        protected uint _id;
        protected float _depth;
        protected float _width;
        protected float _height;
        protected float _weight;

        protected BaseContainer(float depth, float width, float height, float weight) {
            _depth = depth;
            _width = width;
            _height = height;
            _weight = weight;
        }

        public uint Id => _id;
        public float Depth => _depth;
        public float Width => _width;
        public float Height => _height;
    }
}