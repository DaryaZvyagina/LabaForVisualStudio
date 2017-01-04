using laba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba.ViewModels
{
    public class ChatViewModel
    {
        public ObservableCollection<ChatModel> Chat { get; set; } = new ObservableCollection<ChatModel>
        {
            new ChatModel
            {
                FullName = "Даша Звягина",
                Message = "Привет!",
                Image = "http://www.netsareus.ru/Resourse/First/Pictures/SmallPic92825849282584.jpg",
            },
        };
    }
}
