using pawdoc.Class;
using System;
using System.Windows;
using System.Windows.Controls;

namespace pawdoc.component
{
    /// <summary>
    /// Interaction logic for DiaryComponent.xaml
    /// </summary>
    public partial class DiaryComponent : UserControl
    {
        private DiaryEntry diaryEntry;

        // Define an event to notify the parent page of a delete action
        public event Action<DiaryEntry> OnDelete;

        public DiaryComponent(DiaryEntry diaryEntry)
        {
            this.diaryEntry = diaryEntry;
            InitializeComponent();
            SetData();
        }

        public void SetData()
        {
            PetNameTextBox.Text = diaryEntry.Petname.ToString();
            PetIDTextBox.Text = diaryEntry.Id.ToString();
            SymptomsTextBox.Text = diaryEntry.Symptoms.ToString();
            DiagnosisTextBox.Text = diaryEntry.Diagnosis.ToString();
            MedicineTextBox.Text = diaryEntry.Medicine.ToString();
            NotesTextBox.Text = diaryEntry.ExtraNote.ToString();
        }

        // Handle the delete button click
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Trigger the OnDelete event to notify the parent of the deletion
            OnDelete?.Invoke(diaryEntry);
        }
    }
}
