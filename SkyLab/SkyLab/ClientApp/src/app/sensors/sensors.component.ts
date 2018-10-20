import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiRoutes } from '../../services/app.constants';

@Component({
  selector: 'app-sensors',
  templateUrl: './sensors.component.html'
})
export class SensorsComponent {
  public sensors: Sensor[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Sensor[]>(baseUrl + ApiRoutes.getSensors).subscribe(result => {
      this.sensors = result;
    }, error => console.error(error));
  }
}

interface Sensor {
  cellName: string;
  id: number;
  updatedAt: Date;
  comments: string;
}
