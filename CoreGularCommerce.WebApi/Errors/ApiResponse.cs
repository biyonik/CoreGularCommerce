namespace CoreGularCommerce.WebApi.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageForStatus(statusCode);
        }

        private string GetMessageForStatus(int statusCode)
        {
            return statusCode switch 
            {
                400 => "Geçersiz bir istekte bulundunuz!",
                401 => "Yetkisiz erişim isteğinde bulundunuz!",
                404 => "Kaynak bulunamadı! İsteğinize cevap verilemiyor!",
                500 => "İç sunucu hatası!",
                _   => string.Empty
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}