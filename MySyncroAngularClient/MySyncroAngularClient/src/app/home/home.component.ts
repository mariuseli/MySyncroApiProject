import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  pageTitle = 'Accueil';
  versions = ['v1', 'v2', 'v3', 'Currrent'];

  constructor() { }

  ngOnInit(): void {
  }

}
