import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/concatMap';
import { Router, ActivatedRoute } from '@angular/router';
import { Sensor, Cell, CellSensors } from '../../services/models';

@Component({
  selector: 'app-cell',
  templateUrl: './cell.component.html',
  styleUrls: ['./cell.component.css']
})
export class CellComponent implements OnInit {

  public cell: CellSensors;

  constructor(private http: HttpClient,
     @Inject('BASE_URL') private baseUrl: string,
   private activatedRoute: ActivatedRoute) {
  }

  ngOnInit() {
    this.activatedRoute.params
    .concatMap((params) => {
      const id = params['id'];
      console.log(id);
      return this.http.get<CellSensors>(this.baseUrl + 'api/cells/' + id);
    }).subscribe(result => {
      console.log(result);
      this.cell = result;
    }, error => console.error(error));
}
}
