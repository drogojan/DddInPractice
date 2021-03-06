﻿using DddInPractice.Logic;
using NHibernate;

//using NHibernate;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            SnackMachine snackMachine;
            snackMachine = new SnackMachine();
            using (ISession session = SessionFactory.OpenSession())
            {
                snackMachine = session.Get<SnackMachine>(1L);
            }
            var viewModel = new SnackMachineViewModel(snackMachine);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
