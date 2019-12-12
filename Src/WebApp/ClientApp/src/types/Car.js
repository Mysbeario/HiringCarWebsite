class Car {
	constructor(id = 0, numberPlate = "", carTypeName = "", imgPath = "", cost = 0, seat = 0, color = "") {
		this.id = id;
		this.numberPlate = numberPlate;
		this.carTypeName = carTypeName;
		this.imgPath = imgPath;
		this.cost = cost;
		this.seat = seat;
		this.color = color;
	}
}

export default Car;