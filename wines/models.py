from django.db import models
from django.core.validators import MaxValueValidator, MinValueValidator
from families.models import Family
from contests.models import Contest

# Create your models here.
class Wine(models.Model):
    name = models.CharField(max_length=256)
    year = models.IntegerField(validators=[MaxValueValidator(2022), MinValueValidator(1960)])
    pdo = models.CharField(max_length=64)
    contest = models.ForeignKey(Contest, on_delete=models.CASCADE)
    family = models.ForeignKey(Family, on_delete=models.CASCADE)
    
    def __str__(self):
        return f"{self.name} - {self.creator.get_username()} - Contest:{self.contest}"