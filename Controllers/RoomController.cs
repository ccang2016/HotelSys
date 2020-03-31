using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSys.Bll;
using HotelSys.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelSys.Controllers
{
    public class RoomController : Controller
    {

        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            List<Room> rooms = _roomService.GetAllRooms();

            return View(rooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            _roomService.AddRoom(room);

            return Redirect("/Room/Index");
        }


    }
}