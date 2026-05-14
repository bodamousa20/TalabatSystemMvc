namespace TalabatSmartVillage.ViewModel.AccountViewModel
{
    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; } = [];
    }
}
