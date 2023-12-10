import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css'],
})
export class ProfessoresComponent implements OnInit {
  constructor() {}

  titulo = 'Professores';

  public professores = [
    { nome: 'Marta' },
    { nome: 'Paula' },
    { nome: 'Laura' },
    { nome: 'Luiza' },
    { nome: 'Lucas' },
    { nome: 'Pedro' },
    { nome: 'Paulo' },
  ];

  ngOnInit() {}
}
