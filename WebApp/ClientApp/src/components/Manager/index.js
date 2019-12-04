import _CarTypeManager from "./CarTypeManager";
import _CarManager from "./CarManager";
import withManager from "./ManagerHOC";
 
const CarTypeManager = withManager(_CarTypeManager,"/api/pagination/cartype/");
const CarManager = withManager(_CarManager,"/api/pagination/car/");

export { CarTypeManager , CarManager };