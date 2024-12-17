using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Components;

namespace WpfApp.ViewModel
{
    public class StudentFacilitiesViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private string _imageSource;

        public StudentFacilitiesViewModel()
        {
            // Initialize the data for UI binding
            Title = "Student Facilities";
            Description = @"At MTC, we believe in supporting students by providing accessible and affordable public transport options. Here are some exclusive facilities designed for students:

1. **Discounted Fares**
   - Students can enjoy reduced ticket prices on all bus and train routes by registering with a valid student ID. Save more while commuting to school or college.

2. **Monthly and Annual Passes**
   - Special subscription options tailored for students, including:
     - Monthly Passes for unlimited rides.
     - Semester and Annual Subscriptions for hassle-free travel throughout the academic year.

3. **Dedicated Student Helpline**
   - Get support for all transport-related queries. Our dedicated helpline is available to assist students with travel planning and ticket purchases.

4. **Eco-Friendly Travel**
   - Join our green initiative! Students can opt for digital tickets and passes, reducing paper waste and supporting sustainable practices.

5. **Campus Shuttle Services**
   - Exclusive shuttle services for partnered colleges and universities, ensuring safe and convenient travel to and from campus.

**How to Access These Facilities?**
- Download the app and create an account using your student credentials.
- Verify your student status to unlock discounts and offers.
- Choose a subscription that suits your needs, or buy single tickets directly through the app.";
            ImageSource = Resource.Student_Facilities;
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
