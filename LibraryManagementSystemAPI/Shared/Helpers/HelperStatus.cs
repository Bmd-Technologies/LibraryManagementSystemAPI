namespace LibraryManagementSystemAPI.Shared.Helpers
{
    public class HelperStatus
    {
        public static readonly string STATUS_DRAFT = "DRAFT";
        public static readonly string STATUS_SENT = "SEND";
        public static readonly string STATUS_VIEWED = "VIEWED";
        public static readonly string STATUS_COMPLETED = "COMPLETED";

        public static readonly string STATUS_UNPAID = "UNPAID";
        public static readonly string STATUS_PARTIALLY_PAID = "PARTIALLY_PAID";
        public static readonly string STATUS_PAID = "PAID";

        public static readonly string PAYMENT_MODE_CHECK = "CHECK";
        public static readonly string PAYMENT_MODE_OTHER = "OTHER";
        public static readonly string PAYMENT_MODE_CASH = "CASH";
        public static readonly string PAYMENT_MODE_CREDIT_CARD = "CREDIT_CARD";
        public static readonly string PAYMENT_MODE_BANK_TRANSFER = "BANK_TRANSFER";

    }
}
