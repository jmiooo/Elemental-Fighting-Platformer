using UnityEngine;
using System.Collections;

/* a class for storing the current state and transition */
public class TransStats
{
  /* current state */
  public int stateCurrent
  {
    get;
    set;
  }

  /* transition encoding */
  public int transition
  {
    get;
    set;
  }
}

class TransEqualityComparer : IEqualityComparer<TransStats>
{
  public bool Equals(TransStats stats0, TransStats stats1)
  {
    return stats0.stateCurrent == stats1.stateCurrent
        && stats0.transition == stats1.transition;
  }
}

/* FSM implementation */
public class FSM
{
  private Dictionary<TransStats, int> stateMap;
  private int stateCurrent;

  /* 
   * initialize the dictionary with the transition matrix;
   * each index in the matrix corresponds to the next state;
   * REQUIRES: length of inputMatrix is equal to nstate
   */
  void FSM(List<TransStats>[] inputMatrix, int nstate)
  {
    List<TransStats> transList;
    TransEqualityComparer transEqC = new TransEqualityComparer();
    stateMap = new Dictionary<TransStats, int>(nstate, transEqC);
    stateCurrent = 1;

    for (int stateNext = 0; stateNext < nstate; stateNext++) {
      transList = inputMatrix[stateNext];
      foreach (TransStats stateStats in transList)
        stateMap.Add(stateStats, nextState);
    }
  }

  /* return the current state */
  int GetState()
  {
    return stateCurrent;
  }
  
  /* reset to the default state, which is encoded as 1 */
  void Reset()
  {
    stateCurrent = 1;
  }

  void Transition(TransStats transition)
  {
    if (stateMap.TryGetValue(transition, out nextState)
      stateCurrent = nextState;
  }
}
