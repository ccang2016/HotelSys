using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSys.Bll;
using HotelSys.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelSys.Controllers
{
    public class RoomTypeController : Controller
    {
        private IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        public IActionResult Index()
        {
            List<RoomType> roomTypes = _roomTypeService.GetAllRoomTypes();

            return View(roomTypes);
        }
    }
}