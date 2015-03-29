using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
  
  public int GetHashCode(TransStats trans)
  {
    return ((trans.stateCurrent*1103515245 + 12345)
           + trans.transition)*1103515245 + 12345;
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
   * the 0th index is the null state, 1st index is the init state;
   * REQUIRES: length of inputMatrix is equal to nstate
   */
  public FSM(List<TransStats>[] inputMatrix, int nstate)
  {
    List<TransStats> transList;
    TransEqualityComparer transEqC = new TransEqualityComparer();
    stateMap = new Dictionary<TransStats, int>(nstate, transEqC);
    stateCurrent = 1;

    for (int stateNext = 0; stateNext < nstate; stateNext++) {
      transList = inputMatrix[stateNext];
      foreach (TransStats stateStats in transList)
        stateMap.Add(stateStats, stateNext);
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

  int Transition(TransStats transition)
  {
    int stateNext;
    if (stateMap.TryGetValue(transition, out stateNext))
      stateCurrent = stateNext;
    return stateCurrent;
  }
}
