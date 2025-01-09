from django.db import models
from django.contrib.auth.models import User

# Create your models here.
class Family(models.Model):
    name = models.CharField(max_length=128)

    def __str__(self):
        return f"{self.name}"

    class Meta:
        verbose_name_plural = "families"

class Profile(models.Model):
    user = models.OneToOneField(User, on_delete=models.CASCADE)
    family = models.ForeignKey(Family, blank=True, null=True, on_delete=models.SET_NULL)

    def __str__(self):
        result = f"{self.user.username}"
        if self.family is not None:
            result += f" (Family: {self.family.name})"
        return result
