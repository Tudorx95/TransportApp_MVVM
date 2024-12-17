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
    public class Pupils_FreeViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private string _imageSource;

        public Pupils_FreeViewModel()
        {
            // Initialize the data
            Title = "Pupils Facilities Free";
            Description = @"At MTC, we are proud to offer free transportation facilities for school pupils, ensuring they can travel safely and conveniently without financial burden. Here’s how we support young learners:

1. **Free Bus Passes**  
   - Pupils up to a certain grade level are eligible for free bus passes, which can be used for unlimited rides to and from school.

2. **Dedicated School Routes**  
   - Specially designed routes to cover schools across the city, ensuring timely and safe transport for pupils.

3. **Safety First**  
   - All buses for pupils are equipped with CCTV, GPS tracking, and trained staff to ensure the highest level of safety and security.

4. **Digital Pass Management**  
   - Parents and guardians can manage free passes through our app, allowing real-time tracking and seamless renewal.

5. **Inclusive Facilities**  
   - Our buses are accessible to pupils with special needs, providing ramps, priority seating, and other support.

**How to Avail Free Facilities?**  
- Register your child through our app or at the nearest MTC office.  
- Provide proof of enrollment in a recognized school.  
- Collect the free bus pass and enjoy hassle-free commuting!  

Let’s make education more accessible with free transportation for pupils. Together, we’re building a brighter future!";
            ImageSource = Resource.Pupils_Facilities;
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
