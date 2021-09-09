using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadManager.Data;
using BreadManager.Models;
using BreadManager.View;

namespace BreadManager.Controller
{
    public class BreadController
    {
        private BreadView breadView;
        private BreadRepository repository;
        private UserInputValidation userIV;

        public BreadController()
        {
            breadView = new BreadView();
            repository = new BreadRepository();
            userIV = new UserInputValidation();
        }

        public void Bake() // This is Run()
        {
            bool keepBaking = true;

            breadView.WelcomeMessage();

            while (keepBaking)
            {
                int menuChoice = breadView.ShowMenuAndGetChoice();

                switch (menuChoice)
                {
                    case 1:
                        AddBread();
                        break;
                    case 2:
                        ShowAllBread();
                        break;
                    case 3:
                        ObserveBread();
                        break;
                    case 4:
                        ModifyBread();
                        break;
                    case 5:
                        ThrowStaleBread();
                        break;
                    case 6:
                        EligibleBread();
                        break;
                    case 7:  //Exit the kitchen
                        keepBaking = false;
                        break;
                }
            }
        }

        private void AddBread()
        {
            Bread freshBread = breadView.GetFreshBreadInformation();
            Bread breadOnShelf = repository.CreateBread(freshBread);

            if (breadOnShelf != null)
            {
                breadView.PerceiveBread(breadOnShelf);
                breadView.ShowSuccess("Add Bread");
            }
            else
            {
                breadView.ShowFailure("Add Bread");
            }
        }

        private void ShowAllBread()
        {
            Bread[] loaves = repository.RetrieveAllLoaves();

            for (int l = 0; l < loaves.Length; l++)
            {
                if (loaves[l] == null)  // no bread in current position, continue to next position until array has finished looping
                {
                    continue;
                }
                else
                {
                    breadView.PerceiveBread(loaves[l]);
                }
            }
            breadView.ShowSuccess("Show All Loaves");
        }

        private void ObserveBread()
        {
            int breadNumber = userIV.ReadInt("Which loaf would you like to see? ", 0, 9);
            Bread breadSelected = repository.RetrieveBreadByID(breadNumber);

            if (breadSelected == null)
            {
                breadView.ShowFailure("View Bread");  
            }
            else
            {
                breadView.PerceiveBread(breadSelected);
                breadView.ShowSuccess("View Bread");
            }
        }

        private void ModifyBread()
        {
            int breadNumber = userIV.ReadInt("Which bread would you like to change? ", 0, 9);
            Bread breadModified = repository.RetrieveBreadByID(breadNumber);

            if (breadModified == null)
            {
                breadView.ShowFailure("Modify Bread");
            }
            else
            {
                breadModified = breadView.GetFreshBreadInformation();
                breadModified.BreadID = breadNumber;
                repository.EditBread(breadModified);
                breadView.PerceiveBread(breadModified);
                breadView.ShowSuccess("Modify Bread");
            }
        }

        private void ThrowStaleBread()
        {
            int breadNumber = userIV.ReadInt("Which bread would you like to throw away? ", 0, 9);
            Bread breadYeeted = repository.RetrieveBreadByID(breadNumber);

            if(breadYeeted == null)
            {
                breadView.ShowFailure("Throw Bread");
            }
            else
            {
                repository.DeleteBread(breadNumber);
                breadView.ShowSuccess("Throw Bread");
            }
        }

        private void EligibleBread()
        {
            breadView.DisplayEligibleBreadTypes();
            breadView.ShowSuccess("Eligible Bread Types");
        }
    }
}
