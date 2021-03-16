import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { HousesModel } from './commonServices/models/hause.model';
import { HauseService } from './commonServices/services/hause.service';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})

export class AppComponent implements OnInit {
  title = 'realstate';
  blocks: HousesModel[];
  displayedColumns: string[] = ['address', 'year', 'listPrice', 'monthlyRent', 'grossYield'];


  dataSource: MatTableDataSource<HousesModel>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private hauseService: HauseService) {
  }

  ngOnInit() {
    this.onClickBusqueda();
  }

  onClickBusqueda() {
    this.hauseService.getHauseSummary()
      .subscribe(data => {
        this.dataSource = new MatTableDataSource<HousesModel>(data);
      });
  }
}
