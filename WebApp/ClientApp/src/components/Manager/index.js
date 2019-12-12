import _CarTypeManager from "./CarTypeManager";
import _CarManager from "./CarManager";
import _BookingManager from "./BookingManager";
import _UserManager from "./UserManager"
import withManager from "./ManagerHOC";
 
const CarTypeManager = withManager(_CarTypeManager,"/api/pagination/cartype/");
const CarManager = withManager(_CarManager,"/api/pagination/car/");
const BookingManager = withManager(_BookingManager, "/api/pagination/booking/");
const UserManager = withManager(_UserManager,"/api/pagination/user/");

export { CarTypeManager , CarManager, BookingManager, UserManager };