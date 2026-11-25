using Microsoft.Practices.Prism.ViewModel;
using Samba.Domain.Models.Tickets;
using Samba.Presentation.Services;
using System.ComponentModel.Composition;

namespace Samba.Modules.FastPayModule
{
    [Export]
    public class MiniTicketViewModel : NotificationObject
    {
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public MiniTicketViewModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public Ticket SelectedTicket { get; set; }

        public decimal RemainingAmount => SelectedTicket?.GetRemainingAmount() ?? 0;
        public decimal Total => SelectedTicket?.GetSum() ?? 0;

        public void RefreshSelectedItems()
        {
            RaisePropertyChanged(() => RemainingAmount);
            RaisePropertyChanged(() => Total);
        }

        public void CloseTicket()
        {
            if (SelectedTicket == null) return;
            _ticketService.CloseTicket(SelectedTicket);
        }
    }
}
