export interface Sensor {
  sensorName: string;
  id: number;
  comments: string;
}

export interface Cell {
  cellName: string;
  id: number;
  updatedAt: Date;
  comments: string;
}

export interface CellSensors {
  cell: Cell;
  sensors: Sensor[];
}
