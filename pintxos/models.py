from django.db import models
from django.core.validators import MaxValueValidator, MinValueValidator
from families.models import Profile
from contests.models import Contest

# Create your models here.
class Pintxo(models.Model):
    name = models.CharField(max_length=256)
    description = models.TextField()
    creator = models.ForeignKey(Profile, on_delete=models.CASCADE)
    contest = models.ForeignKey(Contest, on_delete=models.CASCADE)
    voted_by = models.ManyToManyField(Profile, through='PintxoVote', related_name='voter')

    def __str__(self):
        return f"'{self.name}' by {self.creator.user.get_username()} - Contest:{self.contest}"

class PintxoVote(models.Model):
    pintxo = models.ForeignKey(Pintxo, on_delete=models.CASCADE)
    voter = models.ForeignKey(Profile, on_delete=models.CASCADE)
    value = models.IntegerField(validators=[MaxValueValidator(10), MinValueValidator(1)])

    def __str__(self):
        return f"{self.pintxo.name} - {self.voter.user.get_username()} - {self.value}"