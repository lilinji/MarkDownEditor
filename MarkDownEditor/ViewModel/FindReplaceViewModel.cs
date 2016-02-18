using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ICSharpCode.AvalonEdit.Document;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using MarkDownEditor.Model;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MarkDownEditor.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class FindReplaceViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public FindReplaceViewModel()
        {
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }

        private bool showFindReplaceControl = false;
        public bool ShowFindReplaceControl
        {
            get { return showFindReplaceControl; }
            set
            {
                if (showFindReplaceControl == value)
                    return;
                showFindReplaceControl = value;
                RaisePropertyChanged("ShowFindReplaceControl");
            }
        }

        private bool isFindPreviousEnabled = false;
        public bool IsFindPreviousEnabled
        {
            get { return isFindPreviousEnabled; }
            set
            {
                if (isFindPreviousEnabled == value)
                    return;
                isFindPreviousEnabled = value;
                RaisePropertyChanged("IsFindPreviousEnabled");
            }
        }

        private bool isFindNextEnabled = false;
        public bool IsFindNextEnabled
        {
            get { return isFindNextEnabled; }
            set
            {
                if (isFindNextEnabled == value)
                    return;
                isFindNextEnabled = value;
                RaisePropertyChanged("IsFindNextEnabled");
            }
        }

        private bool isReplaceNextEnabled = false;
        public bool IsReplaceNextEnabled
        {
            get { return isReplaceNextEnabled; }
            set
            {
                if (isReplaceNextEnabled == value)
                    return;
                isReplaceNextEnabled = value;
                RaisePropertyChanged("IsReplaceNextEnabled");
            }
        }

        private bool isReplaceAllEnabled = false;
        public bool IsReplaceAllEnabled
        {
            get { return isReplaceAllEnabled; }
            set
            {
                if (isReplaceAllEnabled == value)
                    return;
                isReplaceAllEnabled = value;
                RaisePropertyChanged("IsReplaceAllEnabled");
            }
        }

        private bool isMatchCase = false;
        public bool IsMatchCase
        {
            get { return isMatchCase; }
            set
            {
                if (isMatchCase == value)
                    return;
                isMatchCase = value;
                RaisePropertyChanged("IsMatchCase");
            }
        }

        private bool isMatchWholeWord = false;
        public bool IsMatchWholeWord
        {
            get { return isMatchWholeWord; }
            set
            {
                if (isMatchWholeWord == value)
                    return;
                isMatchWholeWord = value;
                RaisePropertyChanged("IsMatchWholeWord");
            }
        }

        private bool useRegExp = false;
        public bool UseRegExp
        {
            get { return useRegExp; }
            set
            {
                if (useRegExp == value)
                    return;
                useRegExp = value;
                RaisePropertyChanged("UseRegExp");
            }
        }

        private bool useWildcards = false;
        public bool UseWildcards
        {
            get { return useWildcards; }
            set
            {
                if (useWildcards == value)
                    return;
                useWildcards = value;
                RaisePropertyChanged("UseWildcards");
            }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText == value)
                    return;
                searchText = value;
                RaisePropertyChanged("SearchText");
                UpdateCommandsState();
            }
        }

        private string replaceText;
        public string ReplaceText
        {
            get { return replaceText; }
            set
            {
                if (replaceText == value)
                    return;
                replaceText = value;
                RaisePropertyChanged("ReplaceText");
                UpdateCommandsState();
            }
        }

        #region Commands
        public ICommand SwitchFindReplaceCommand => new RelayCommand(() => ShowFindReplaceControl = !ShowFindReplaceControl);
        public ICommand ShowFindReplaceCommand => new RelayCommand(() => ShowFindReplaceControl = true);
        public ICommand HideFindReplaceCommand => new RelayCommand(() => ShowFindReplaceControl = false);


        public ICommand FindPreviousCommand => new RelayCommand(() =>
        {

        });

        public ICommand FindNextCommand => new RelayCommand(() =>
        {

        });

        public ICommand ReplaceNextCommand => new RelayCommand(() =>
        {

        });

        public ICommand ReplaceAllCommand => new RelayCommand(() =>
        {

        });
        #endregion //Commands


        #region Functions
        private void UpdateCommandsState()
        {
            if (string.IsNullOrEmpty(SearchText))
                ClearFindState();
            else
            {
                var mainVM = ViewModelLocator.Main;
                RegexOptions options = RegexOptions.None;
                if (!IsMatchCase)
                    options |= RegexOptions.IgnoreCase;
                Regex regex = new Regex(SearchText, options);
                var collections = regex.Matches(mainVM.SourceCode.Text);
                if (collections.Count == 0)//nothing matched
                {
                    ClearFindState();
                    return;
                }

            }   
        }
        
        private void ClearFindState()
        {
            IsFindPreviousEnabled = false;
            IsFindNextEnabled = false;
            IsReplaceNextEnabled = false;
            IsReplaceAllEnabled = false;            
        }
        #endregion //Functions
    }
}