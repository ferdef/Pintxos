from django.db import models
from django.core.validators import MaxValueValidator, MinValueValidator
from django.contrib.auth.models import User
from contests.models import Contest

# Create your models here.
class Pintxo(models.Model):
    name = models.CharField(max_length=256)
    description = models.TextField()
    creator = models.ForeignKey(User, on_delete=models.CASCADE)
    contest = models.ForeignKey(Contest, on_delete=models.CASCADE)

    def __str__(self):
        return f"{self.name} - {self.creator.get_username()} - Contest:{self.contest}"

class PintxoVote(models.Model):
    pintxo = models.ForeignKey(Pintxo, on_delete=models.CASCADE)
    voter = models.ForeignKey(User, on_delete=models.CASCADE)
    value = models.IntegerField(validators=[MaxValueValidator(10), MinValueValidator(1)])

    def __str__(self):
        return f"{self.pintxo.name} - {self.voter.get_username()} - {self.value}"