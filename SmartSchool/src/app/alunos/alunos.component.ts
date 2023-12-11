import { Component, OnInit, TemplateRef } from '@angular/core';
import { Aluno } from '../models/Aluno';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css'],
})
export class AlunosComponent implements OnInit {
  public alunoForm: FormGroup;
  public titulo = 'Alunos';
  public alunoSelecionado!: Aluno;
  public modalRef!: BsModalRef;

  constructor(private fb: FormBuilder, private modalService: BsModalService) {
    this.criarForm();
  }

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit(): void {}

  criarForm() {
    this.alunoForm = this.fb.group({
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required],
    });
  }

  public alunos = [
    { id: 1, nome: 'Marta', sobrenome: 'Kent', telefone: '54246743' },
    { id: 2, nome: 'Paula', sobrenome: 'Isabela', telefone: '634562345' },
    { id: 3, nome: 'Laura', sobrenome: 'Antonia', telefone: '641467824' },
    { id: 4, nome: 'Luíza', sobrenome: 'Maria', telefone: '756435234' },
    { id: 5, nome: 'Lucas', sobrenome: 'Machado', telefone: '765234895' },
    { id: 6, nome: 'Pedro', sobrenome: 'Alvares', telefone: '234754643' },
    { id: 7, nome: 'Paulo', sobrenome: 'José', telefone: '756234654' },
  ];

  alunoSubmit() {
    console.log(this.alunoForm.value);
  }

  alunoSelect(aluno: Aluno) {
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  voltar() {
    this.alunoSelecionado = null;
  }
}
