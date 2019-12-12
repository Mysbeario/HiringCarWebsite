import _CarTypeManager from "./CarTypeManager";
import _CarManager from "./CarManager";
import _BookingManager from "./BookingManager";
import withManager from "./ManagerHOC";
 
const CarTypeManager = withManager(_CarTypeManager,"/api/pagination/cartype/");
const CarManager = withManager(_CarManager,"/api/pagination/car/");
const BookingManager = withManager(_BookingManager, "/api/pagination/booking/");

export { CarTypeManager , CarManager, BookingManager };