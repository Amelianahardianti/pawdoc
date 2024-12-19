using pawdoc.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pawdoc.component
{
    /// <summary>
    /// Interaction logic for DiaryComponent.xaml
    /// </summary>
    public partial class DiaryComponent : UserControl
    {
        DiaryEntry diaryEntry;
        public DiaryComponent(DiaryEntry diaryEntry)
        {
            this.diaryEntry = diaryEntry;
            InitializeComponent();
            SetData();
        }

        public void SetData() {
            PetNameTextBox.Text = diaryEntry.Petname.ToString();
            PetIDTextBox.Text = diaryEntry.Id.ToString();
            SymptomsTextBox.Text = diaryEntry.Symptoms.ToString();
            DiagnosisTextBox.Text = diaryEntry.Diagnosis.ToString();
            MedicineTextBox.Text = diaryEntry.Medicine.ToString();
            NotesTextBox.Text = diaryEntry.ExtraNote.ToString();
        }
    }
}
