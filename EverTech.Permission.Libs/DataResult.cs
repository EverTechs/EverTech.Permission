namespace EverTech.Permission.Libs
{
    public class DataResult<T>
    {
        public bool IsOk { get; set; }
        public T Data { get; set; }
        public string Msg { get; set; }
        public object ExtData { get; set; }

        public DataResult()
        {
            IsOk = true;
        }
        public DataResult(T data)
        {
            IsOk = true;
            Data = data;
        }
        public DataResult(T data, object extData)
        {
            IsOk = true;
            Data = data;
            ExtData = extData;
        }
        public DataResult(bool isOk, string msg)
        {
            IsOk = isOk;
            Msg = msg;
        }
        public DataResult(bool isOk, string msg, object extData)
        {
            IsOk = isOk;
            Msg = msg;
            ExtData = extData;
        }

    }
}
