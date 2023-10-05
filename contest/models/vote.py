from django.db import models
from django.contrib.auth.models import User
from . import Pintxo

from .choices import Tastes, Presentations, Originalities

class Vote(models.Model):
    taste_vote = models.CharField(max_length=2, choices=Tastes.choices)
    presentation_vote = models.CharField(max_length=2, choices=Presentations.choices)
    originality_vote = models.CharField(max_length=2, choices=Originalities.choices)
    pintxo = models.ForeignKey(Pintxo, on_delete=models.CASCADE)
    voter = models.ForeignKey(User, on_delete=models.CASCADE)

    def __unicode__(self):
        return f"{self.voter.get_full_name()} voted {self.taste_vote} - {self.presentation_vote} - {self.originality_vote}"
    
    def __str__(self):
        return f"{self.voter.get_full_name()} voted {self.taste_vote} - {self.presentation_vote} - {self.originality_vote}"