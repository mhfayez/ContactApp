using System;

using System.Windows.Input;
using ContactApp.Model;

namespace ContactApp.ViewModel
{
    public class DeleteCommand : ICommand
    {

        private ContactCatalog _catalog;
        private ContactViewModel _viewModel;

        public DeleteCommand(ContactCatalog catalog, ContactViewModel viewModel)
        {
            _catalog = catalog;
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return _viewModel.SelectedContact != null;
        }

        public void Execute(object parameter)
        {
            // Delete from catalog
            _catalog.DeleteAsync(_viewModel.SelectedContact.Phone);
            // Set selection to null
            _viewModel.SelectedContact = null;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
