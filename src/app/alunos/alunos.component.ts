import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css'],
})
export class AlunosComponent {
  public titulo = 'Alunos';

  public alunos = [
    { id: 1, nome: 'Marta', sobrenome: 'Kent', telefone: '54246743' },
    { id: 2, nome: 'Paula', sobrenome: 'Isabela', telefone: '634562345' },
    { id: 3, nome: 'Laura', sobrenome: 'Antonia', telefone: '641467824' },
    { id: 4, nome: 'Luíza', sobrenome: 'Maria', telefone: '756435234' },
    { id: 5, nome: 'Lucas', sobrenome: 'Machado', telefone: '765234895' },
    { id: 6, nome: 'Pedro', sobrenome: 'Alvares', telefone: '234754643' },
    { id: 7, nome: 'Paulo', sobrenome: 'José', telefone: '756234654' },
  ];
}
